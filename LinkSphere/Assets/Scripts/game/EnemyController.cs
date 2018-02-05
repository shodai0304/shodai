using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    
    public float rad;
    private Vector3 pos;

    float speed = 0.05f;
    Transform cachedTransform;


    // Use this for initialization
    void Start()
    {
        cachedTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //rad = Mathf.Atan2(OrbController._GetInstance.transform.position.x - transform.position.x, 
        //                    OrbController._GetInstance.transform.position.z - transform.position.z);

        //pos.x += speed * Mathf.Sin(rad);
        //pos.z += speed * Mathf.Cos(rad);
        //transform.position = pos;

        var aim = OrbController._GetInstance.transform.position - transform.position;
        var look = Quaternion.LookRotation(aim);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, look, Time.deltaTime / 2);
        Vector3 moveVec = (look * Vector3.forward * speed);
        moveVec.y = 0.0f;
        cachedTransform.position = transform.position + moveVec;
    }
}
