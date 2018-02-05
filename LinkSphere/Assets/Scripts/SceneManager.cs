using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public bool _isGame;


    //-----シーンプレハプ-----
    //public GameObject _TitlePrefab;
    public GameObject _GamePrefab;          //ゲームシーン

    private GameObject _NowObj, _OldObj;    //Destroy用オブジェクト変数

    //シングルトン
    private static SceneManager _Singleton;
    public static SceneManager _GetInstance
    {
        get { return _Singleton; }
    }

    void Awake()
    {
        //シングルトン
        if (_Singleton == null) { _Singleton = this; }
        else { Destroy(this); }
        DontDestroyOnLoad(this);
        //シーン選択
        //SetState(1);
    }

    // Use this for initialization
    void Start () {
        _isGame = true;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    ///ゲーム遷移
    ///戻り値：なし
    ///引　数：遷移先の番号
    /// </summary>
    public void SetState(int state)
    {
        GameObject obj = null;
        switch (state)
        {
            case 0://タイトル
                //obj = _TitlePrefab;
                break;
            case 1://ゲーム
                obj = _GamePrefab;
                break;
        }
        //OldObjに今のシーンを入れて遷移先のシーンを生成。古いシーンがあれば消す
        _OldObj = _NowObj;
        _NowObj = Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
        if (_OldObj != null) { Destroy(_OldObj); }
    }
}
