using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private int     _ID;
    [SerializeField]
    private float   _hp, _Atk, _Def;

	// Use this for initialization
	void Start () {
        
        _hp = 100;
        _Atk = 50;
        _Def = 30;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Orb" && OrbController._GetInstance._isMove)
        {
            OrbController._GetInstance.transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
            OrbController._GetInstance._isMove = false;
        }
    }
}
