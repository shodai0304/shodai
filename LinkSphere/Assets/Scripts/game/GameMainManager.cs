using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainManager : MonoBehaviour {

    private string Tag = "Player";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //マウスクリックした場所からRayを飛ばし、オブジェクトがあればtrue 
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.CompareTag(Tag))
                {
                    //hit.collider.gameObject.GetComponent<OrbController>().OnUserAction();
                    OrbController._GetInstance.SetPos(hit.collider.gameObject.transform.position);
                    OrbController._GetInstance._isMove = true;
                }
            }
        }
    }
}
