using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class template
{
    protected abstract string[] tmps { get; }
}

public class template_1 : template
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

public class template_2 : template
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

public class template_3 : template
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
