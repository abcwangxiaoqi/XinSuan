using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;

public class UIQuestion : TTUIPage
{
    public UIQuestion()
        :base(UIType.Normal,UIMode.DoNothing,UICollider.None)
    {
        uiPath = "UIQuestion";
    }

    Text title;
    Text ACon;
    Text BCon;
    Text CCon;
    Text DCon;

    public override void Awake(GameObject go)
    {
        base.Awake(go);

        title = go.transform.Find("TitleBg/Text").GetComponent<Text>();

        ACon = go.transform.Find("ContextBg/A/Context").GetComponent<Text>();
        BCon = go.transform.Find("ContextBg/B/Context").GetComponent<Text>();
        CCon = go.transform.Find("ContextBg/C/Context").GetComponent<Text>();
        DCon = go.transform.Find("ContextBg/D/Context").GetComponent<Text>();
    }
}
