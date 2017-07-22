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
        ConfigMoudle moudle = new ConfigMoudle();
        moudle.Count = int.Parse(this.Count);
        moudle.everyScore = float.Parse(this.everyScore);

        string[] maths = MathTemplate.Split(',');
        moudle.MathTemplate = new List<string>(maths);

        string[] nums = NumsTemplate.Split(',');
        List<float> fnums = new List<float>();

        for (int i = 0; i < nums.Length; i++)
        {
            fnums.Add(float.Parse(nums[i]));
        }

        moudle.NumsTemplate = fnums;

        return moudle;
    }
}

public class ConfigMoudle
{
    public int ID;
    public List<string> MathTemplate;
    public List<float> NumsTemplate;
    public int Count;
    public float everyScore;


    int curIndex = 0;

    public bool next(out string msg)
    {
        curIndex += 1;

        msg = null;
        return true;
    }
}
