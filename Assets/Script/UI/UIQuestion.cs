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
    Text score;
    Text sec;

    public override void Awake(GameObject go)
    {
        base.Awake(go);

        title = go.transform.Find("TitleBg/Text").GetComponent<Text>();

        ACon = go.transform.Find("ContextBg/A/Context").GetComponent<Text>();
        BCon = go.transform.Find("ContextBg/B/Context").GetComponent<Text>();
        CCon = go.transform.Find("ContextBg/C/Context").GetComponent<Text>();
        DCon = go.transform.Find("ContextBg/D/Context").GetComponent<Text>();

        score = go.transform.Find("ScoreBg/score").GetComponent<Text>();
        sec = go.transform.Find("SecBg/sec").GetComponent<Text>();

        score.text = 0.ToString();
        sec.text = 3.ToString();

        resetSec();
    }

    void resetSec()
    {
        NativeTimer timer = new NativeTimer(survtime, 0.01f, true, 300);
        timer.Start();
    }

    float survTime = 3f;
    void survtime()
    {
        survTime -= 0.01f;
        sec.text = survTime.ToString("f2");
        
        if(System.Math.Abs(survTime) < 0.01)
        {
            Debug.Log("finish");
        }
    }
}
