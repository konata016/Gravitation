using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageblocGroup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //子オブジェクトのサイズを取得
        float ChildSizeX = transform.GetChild(0).gameObject.transform.localScale.x;
        //子オブジェクトの数取得
        int ChildCount = transform.childCount;

        //子オブジェクトの数に合わせた大きさのコリダーを1つ生成
        gameObject.AddComponent<BoxCollider>();
        gameObject.GetComponent<BoxCollider>().size = new Vector3(ChildSizeX * ChildCount, ChildSizeX, ChildSizeX);
        gameObject.GetComponent<BoxCollider>().center = Vector3.right * (ChildCount * ChildSizeX / 2);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
