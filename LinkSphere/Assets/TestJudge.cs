using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestJudge : MonoBehaviour {

    Text _text;


    // Use this for initialization
    void Start () {
        _text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetText(int judge)
    {
        switch (judge)
        {
            case 0:
                _text.text = "あなたの";
                break;
            case 1:
                _text.text = "かち";
                break;
            case 2:
                _text.text = "まけ";
                break;
        }
    }
}
