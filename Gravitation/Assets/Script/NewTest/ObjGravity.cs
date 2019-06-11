using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjGravity : MonoBehaviour
{
    Ray Ray_;
    Rigidbody Rb;
    Vector3 V3;
    Vector3 GroundPos;
    bool IsPlayer;
    bool IsSlip;

    public GameObject Target;
    public float Gravity = 200;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        V3 = transform.position;

        //レイを飛ばす
        if (GroundPos.z <= 0) Ray_ = new Ray(transform.position, Vector3.forward);
        if (GroundPos.z >= Target.transform.position.z - 5)  Ray_ = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(Ray_, 100))
        { 
            if (!IsSlip)
            { 
                //慣性の消去
                Rb.velocity = Vector3.zero;
                IsSlip = true;
            }
            else
            {
                //重力＆ずれ修正
                if (GroundPos.z <= 0)
                {
                    Rb.AddForce(Vector3.forward * Gravity);
                    Rb.position = Vector3.MoveTowards(
                        transform.position, new Vector3(V3.x, Target.transform.position.y, V3.z), 10);
                }
                if (GroundPos.z >= Target.transform.position.z - 5)
                {
                    Rb.position = Vector3.MoveTowards(
                       transform.position, new Vector3(V3.x, V3.y, 0), 10);
                    Rb.AddForce(Vector3.down * Gravity);
                }
            }
        }
        else
        {
            if (IsPlayer)
            {
                //移動
                if (GroundPos.z <= 0) Rb.AddForce(Vector3.up * Gravity);
                if (GroundPos.z >= Target.transform.position.z - 5) Rb.AddForce(Vector3.back * Gravity);
            }
        }
        Debug.DrawRay(Ray_.origin, Ray_.direction * 100, Color.red, 0.5f, false);
    }
    private void OnCollisionStay(Collision collision)
    {
        //
        if (collision.gameObject.tag == "Player") IsPlayer = true;
        if (collision.gameObject.tag != "Player") IsPlayer = false;

        //
        Rb.velocity = Vector3.zero;
        IsSlip = false;

        //地面にいたときのポジションを確保
        GroundPos = V3;
    }
}