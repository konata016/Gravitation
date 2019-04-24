using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseChase : MonoBehaviour
{

    Vector3 ScreenPos;
    Vector3 TargetPos;
    Vector3 Velocity;

    public Rigidbody rb;

    private float SmoothTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //マウスの座標取得
        ScreenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 Pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenPos.z);

        //マウスで左クリックしたとき
        if (Input.GetMouseButton(0))
        {
            //追従対象オブジェクトのTransformから、目的地を算出
            TargetPos = Camera.main.ScreenToWorldPoint(Pos);
        }

        //移動
        transform.position =
            Vector3.SmoothDamp(transform.position, TargetPos, ref Velocity, SmoothTime);
    }
}
