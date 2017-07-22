using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class template
{
    protected virtual int Cou
    {
        get
        {
            return 10;
        }
    }
    protected virtual float everyScore
    {
        get
        {
            return 10f;
        }
    }

    protected virtual List<float> singleTmplate
    {
        get
        {
            return null;
        }
    }

    protected abstract string[] tmps { get; }
}

public abstract class template_1 : template
{
    protected override string[] tmps
    {
        get
        {
            return new string[]
            {
                "{0}+{1}",
                "{0}-{1}"
            };
        }
    }
}

public abstract class template_2 : template
{
    protected override string[] tmps
    {
        get
        {
            return new string[]
            {
                "{0}+{1}-{2}",
                "{0}-{1}+{2}",
                "{0}+{1}+{2}",
                "{0}-{1}-{2}",
                "{0}-({1}-{2})",
                "{0}-({1}+{2})",
            };
        }
    }
}

public abstract class template_3 : template
{
    protected override string[] tmps
    {
        get
        {
            return new string[]
            {
                "{0}-({1}-{2})",
                "{0}-({1}+{2})",
            };
        }
    }
}

public abstract class template_4 : template
{
    protected override string[] tmps
    {
        get
        {
            throw new NotImplementedException();
        }
    }
}



//+++++++++++++++++++++++++++++

public interface IQTemplate
{ }

public class QTemplate: template_1, IQTemplate
{
    protected override float everyScore
    {
        get
        {
            return 10f;
        }
    }


    //1.0 代表 1位数 小数点后位数为0 
    //2.1 代表 3位数 整数位为2 小数点后位数为1
    List<float> _singleTmplate = new List<float>() { 1.0f, 1.0f };

    protected override List<float> singleTmplate
    {
        get
        {
            return _singleTmplate;
        }
    }
}


//+++++++++++++++++++++++++
