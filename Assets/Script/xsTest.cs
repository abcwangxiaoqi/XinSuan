using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Question
{
    public int no;
    public string topical;
    public List<string> options;
    public int answer;
}

public abstract class xsPool
{
    protected List<Question> hadPush = new List<Question>();

    /// <summary>
    /// get next question
    /// </summary>
    /// <returns></returns>
    public abstract Question next();


}

public class xsPool_1 : xsPool
{
    int GetNum()
    {
        return UnityEngine.Random.Range(0, 9);
    }

    public override Question next()
    {
        int num1 = GetNum();
        int num2 = GetNum();

        Question result = new Question();

        string topical = string.Format("{0}+{1}",num1,num2);

        bool exist = hadPush.Exists((Question q) => 
        {
            return q.topical == topical;
        });

        while(exist)
        {
            result=next();
        }

        result.no = hadPush.Count + 1;
        result.topical = topical;
        result.options = getOptions(num1 + num2,out result.answer);
        hadPush.Add(result);

        return result;
    }

    List<string> getOptions(int result,out int answer)
    {
        answer = 0;

        List<string> res = new List<string>();
        res.Add(result.ToString());
        res.Add((result - 1).ToString());
        res.Add((result + 1).ToString());
        res.Add((result + 2).ToString());

        res = xsUtil.RandomSortList<string>(res);

        for (int i = 0; i < res.Count; i++)
        {
            if(res[i]==result.ToString())
            {
                answer = i;
            }
        }
        return res;
    }    
}

public abstract class baseTemp
{
    public abstract List<string> temp { get; }
}

public class Temp1
{
    public List<string> temp = new List<string>
    {
        "{0}+{1}",
        "{0}-{1}"
    };
}

public class Temp2
{

}

public sealed class xsUtil
{
    public static List<T> RandomSortList<T>(List<T> ListT)
    {
        System.Random random = new System.Random();
        List<T> newList = new List<T>();
        foreach (T item in ListT)
        {
            newList.Insert(random.Next(newList.Count + 1), item);
        }
        return newList;
    }
}