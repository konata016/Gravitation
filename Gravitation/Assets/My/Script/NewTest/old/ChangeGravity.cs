using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    public GameObject Target;
    public Vector3 Rot;
    public float Gravity;

    public static bool IsGravity;

    Rigidbody Rb;
    Vector3 V3;
    Vector3 GroundPos;
    Vector3 Direction = Vector3.left;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        V3 = transform.position;

        //入力した方向を向く
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) Direction = Vector3.left;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) Direction = Vector3.right;
        transform.rotation = Quaternion.LookRotation(Direction, Rot);

        //重力を変えるフラグを立てる
        if (Target.transform.position.y + 1f < V3.y)
        {
            if ((int)GroundPos.z <= 0) IsGravity = true;
        }
        if (-1f > V3.z)
        {
            if ((int)GroundPos.z >= Target.transform.position.z - 1) IsGravity = false;
        }

        //重力の処理
        if (!IsGround.IsReady && !PlCon2.IsJump)
        {
            if (Rb.velocity.magnitude < 100f)
            {
                if (!IsGravity)
                {
                    //通常重力
                    Rot = Vector3.zero;
                    Rb.AddForce(Vector3.down * Gravity);
                    V3.z = 0f;
                    Rb.position = Vector3.MoveTowards(
                       transform.position, new Vector3(V3.x, V3.y, 0), 10);
                }
                else
                {
                    //奥の重力
                    Rot = new Vector3(0, 0, -1);
                    Rb.AddForce(Vector3.forward * Gravity);
                    V3.y = Target.transform.position.y;
                    Rb.position = Vector3.MoveTowards(
                        transform.position, new Vector3(V3.x, Target.transform.position.y, V3.z), 10);
                }
            }
        }
        //地面にいたときのポジションを確保
       if (IsGround.IsReady) GroundPos = V3;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //ずれた座標の修正
    }
}
