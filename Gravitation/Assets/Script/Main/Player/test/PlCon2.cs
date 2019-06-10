using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlCon2 : MonoBehaviour
{

    Rigidbody Rb;
    Vector3 V3;
    float RivalSpeed;
    float SavePosY;
    bool IsJump;

    public float High;
    public float JumpPower;
    public float Speed;
    public float Gravity;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        RivalSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        V3 = transform.position;

        if (IsGround.IsReady)
        {
            //地面での位置
            SavePosY = transform.position.y;

            //移動
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                Rb.AddForce(RivalSpeed * ((Vector3.left * Speed) - Rb.velocity));
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                Rb.AddForce(RivalSpeed * ((Vector3.right * Speed) - Rb.velocity));
            }

            //慣性を消す
            if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.A) &&
                    !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.D))
            {
                Rb.velocity = new Vector3(0, Rb.velocity.y, 0);
            }

            //ジャンプのフラグ
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
            {
                IsJump = true;
            }
        }
        else
        {
            //移動
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                Rb.AddForce((RivalSpeed * ((Vector3.left * Speed) - Rb.velocity)) / 2);
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                Rb.AddForce((RivalSpeed * ((Vector3.right * Speed) - Rb.velocity)) / 2);
            }

            //重力
            if (!IsJump)
            {
                if (Rb.velocity.magnitude < 100f) Rb.AddForce(Vector3.down * Gravity);
            }
        }

        //ジャンプ
        if (IsJump)
        {
            if (transform.position.y <= High + SavePosY)
            {
                V3.y += JumpPower * Time.deltaTime;
                Rb.position = V3;
            }
            else IsJump = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsJump = false;
    }
}
