using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseChase : MonoBehaviour
{
    public GameObject PlPos;

    Vector3 ScreenPos;
    Vector3 TargetPos;
    Vector3 Velocity;
    Vector3 MousePos;

    float PosZ;
    float SmoothTime;

    // Start is called before the first frame update
    void Start()
    {
        //Planetの初期値
        TargetPos = new Vector3(0, 5, 0);

        //変数名を短くする用
        PosZ = GameGenerator.PlPlanetBackPos;
        SmoothTime = GameGenerator.PlPlanetSmoothTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //マウスの座標取得(z軸はプレイヤーと同じ)
        ScreenPos = Camera.main.WorldToScreenPoint
            (new Vector3(transform.position.x, transform.position.y, PlPos.transform.position.z));
        MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenPos.z);

        //マウスで左クリックしたとき
        if (Input.GetMouseButton(0))
        {
            //追従対象オブジェクトのTransformから、目的地を算出
            TargetPos = Camera.main.ScreenToWorldPoint(MousePos);
        }

        //移動(Qを押した時プラネットが奥へ行く)
        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 Pos = new Vector3(TargetPos.x, TargetPos.y, TargetPos.z + PosZ);
            transform.position = Vector3.SmoothDamp(transform.position, Pos, ref Velocity, SmoothTime);
        }
        else
        {
            transform.position =
               Vector3.SmoothDamp(transform.position, TargetPos, ref Velocity, SmoothTime);
        }
        
    }
}
