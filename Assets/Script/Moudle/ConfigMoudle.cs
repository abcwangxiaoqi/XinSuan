using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class JsonConfig
{
    public static List<ConfigMoudle> Load()
    {        
        string json = Resources.Load<TextAsset>("config/config").text;
        List<ConfigJsonMoudle> list = json.JsonTransferObject<List<ConfigJsonMoudle>>();

        List<ConfigMoudle> res = new List<ConfigMoudle>();

        for (int i = 0; i < list.Count; i++)
        {
            res.Add(list[i].Transfer());
        }

        return res;
    }
}

public class ConfigJsonMoudle
{
    public string ID;
    public string MathTemplate;
    public string NumsTemplate;
    public string Count;
    public string everyScore;

    public ConfigMoudle Transfer()
    {
        return new ConfigMoudle(this);
    }
}

public class ConfigMoudle
{
    public ConfigMoudle(ConfigJsonMoudle moudle)
    {
        this.Count = int.Parse(moudle.Count);
        this.everyScore = float.Parse(moudle.everyScore);

        string[] maths = moudle.MathTemplate.Split(',');
        this.MathTemplate = new List<string>(maths);

        string[] nums = moudle.NumsTemplate.Split(',');
        List<float> fnums = new List<float>();

        for (int i = 0; i < nums.Length; i++)
        {
            fnums.Add(float.Parse(nums[i]));
        }

        this.NumsTemplate = fnums;
    }

    public int ID { get; private set; }
    public List<string> MathTemplate { get; private set; }
    public List<float> NumsTemplate { get; private set; }
    public int Count { get; private set; }
    public float everyScore { get; private set; }

    int hasPush = 0;

    public bool next(out string msg)
    {     
        msg = null;

        if (hasPush == Count)
        {
            //该组已经结束
            return false;
        }


        msg = getQuestion();


        hasPush += 1;

        return true;
    }

    string getQuestion()
    {
        string result = null;

        #region 得到公式
        int mathIndex = Random.Range(0, MathTemplate.Count - 1);
        string math = MathTemplate[mathIndex];
        #endregion

        #region 得到数字

        List<float> nums = new List<float>();

        for (int i = 0; i < NumsTemplate.Count; i++)
        {
            float item = NumsTemplate[i];

            int intCout = (int)item;

            int decimalCout = (int)(item - intCout) * 10;

            int zint = 0;
            if(intCout>0)
            {
                zint = Random.Range((intCout - 1) * 10, intCout * 10 - 1);
            }

            float ddec = 0;
            if(decimalCout>0)
            {
                ddec = Random.Range((decimalCout - 1) * 10, decimalCout * 10 - 1) / (decimalCout * 10);
            }           

            float res = zint + ddec;
            nums.Add(res);
        }

        #endregion

        object[] objs = new object[NumsTemplate.Count];
        for (int i = 0; i < nums.Count; i++)
        {
            objs[i] = nums[i];
        }

        result = string.Format(math, objs);

        return result;
    }
}
