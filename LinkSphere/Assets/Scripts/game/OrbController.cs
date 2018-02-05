using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour {
    
    private Vector3 _vPos;
    public bool _isMove;
    public float _speed = 3.0f;

    private TestJudge _judge;

    //シングルトン
    private static OrbController _Singleton;
    public static OrbController _GetInstance
    {
        get { return _Singleton; }
    }

    void Awake()
    {
        //シングルトン
        if (_Singleton == null) { _Singleton = this; }
        else { Destroy(this); }
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start()
    {
        _judge = FindObjectOfType<TestJudge>();
        _isMove = false;
        transform.position = new Vector3(0.0f, 0.0f, -7.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isMove)
        {
            transform.position = Vector3.Lerp(transform.position, _vPos, Time.deltaTime * _speed);
        }
    }

    public void SetPos(Vector3 pos)
    {
        _vPos = pos;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //Destroy(OrbController._GetInstance.gameObject);
            _judge.SetText(2);

        }
        if (col.gameObject.tag == "EnemyBack")
        {
            //Destroy(OrbController._GetInstance.gameObject);
            _judge.SetText(1);
        }
    }

}
