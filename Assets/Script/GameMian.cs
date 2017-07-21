using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using org.mariuszgromada.math.mxparser;

public class GameMian : MonoBehaviour {

	// Use this for initialization
	void Start () {

        TTUIPage.ShowPage<UIQuestion>();


        string gongshi = "10+2-2*2+100/23 ";

        Expression exp = new Expression(gongshi);
        double res= exp.calculate();
        Debug.Log(res);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
