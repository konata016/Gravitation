using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosChange : MonoBehaviour
{
    Vector3 Velocity;
    Vector3 Pos;
    int Count;

    [Header("移動位置リスト")]
    public GameObject[] TargetPos;

    [Header("見つける位置")]
    public GameObject LookTarget;

    [Header("向かうまでの時間")]
    public float SmoothTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //矢印キー入力で次の星へ
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Count++;
        if (Input.GetKeyDown(KeyCode.RightArrow)) Count--;

        //要素数、参照による制限
        if (Count > TargetPos.Length - 1) Count = 0;
        if (Count < 0) Count = TargetPos.Length - 1;

        //核の方を見る
        transform.LookAt(LookTarget.transform);

        //星のポジション確保
        Pos = TargetPos[Count].transform.position;

        //移動
        transform.position =
            Vector3.SmoothDamp(transform.position, Pos, ref Velocity, SmoothTime);
    }
}
