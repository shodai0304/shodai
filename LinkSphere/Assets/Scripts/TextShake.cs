//****************************************************************************************
//**** Using
//****************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//****************************************************************************************
//**** Class
//****************************************************************************************
public class TextShake : BaseMeshEffect
{
    private float time = 0;
    public float radius = 0.5f;

	
	//****************************************************************************************
	//**** Update
	//****************************************************************************************
	void Update () {
        time += Time.deltaTime;
        if (time > 0.05f)
        {
            time = 0;
            GetComponent<Graphic>().SetVerticesDirty();
        }
    }

	//====================================================================================
	//
	//==== ModifyMesh
	//
	//====================================================================================
	public override void ModifyMesh ( VertexHelper vh )
    {
        if (!IsActive())
            return;

        List<UIVertex> vertices = new List<UIVertex>();
        vh.GetUIVertexStream(vertices);

        TextMove(ref vertices);

        vh.Clear();
        vh.AddUIVertexTriangleStream(vertices);
    }

	//====================================================================================
	//
	//==== TextMove：テキストを動かす処理
	//
	//====================================================================================
	void TextMove( ref List<UIVertex> vertices )
    {
        for (int c = 0; c < vertices.Count; c += 6)
        {
            float rad = UnityEngine.Random.Range(0,360) * Mathf.Deg2Rad;
            Vector3 dir = new Vector3 (radius * Mathf.Cos (rad), radius * Mathf.Sin (rad), 0);

            for(int i = 0; i < 6; i++)
            {
                var vert       = vertices [c+i];
                vert.position  = vert.position + dir;
                vertices [c+i] = vert;
            }
        }
    }
}