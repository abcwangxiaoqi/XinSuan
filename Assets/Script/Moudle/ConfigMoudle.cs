using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        List<float> nums = new List<float>(NumsTemplate.Count);

        for (int i = 0; i < NumsTemplate.Count; i++)
        {

        }

        #endregion

        return result;
    }
}
