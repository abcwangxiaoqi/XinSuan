using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using org.mariuszgromada.math.mxparser;

public class GameMian : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //TTUIPage.ShowPage<UIQuestion>();

        List<ConfigMoudle> list = JsonConfig.Load();

        int index = 0;

        while(index< list.Count)
        {
            string mathStr = null;
            if (list[index].next(out mathStr))
            {
              //  Debug.Log(mathStr);
                Expression exp = new Expression(mathStr);
                double res = exp.calculate();
                Debug.Log(mathStr+"="+res);
            }
            else
            {
                index++;
            }
        }

        Debug.Log("finish");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
