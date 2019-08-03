using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlCon : MonoBehaviour
{
    Rigidbody Rb;
    float RivalSpeed;
    float JumpStartTime;
    bool IsJumping = false;
    float DefaultY;
    Vector3 V3;

    public float Speed = 10f;
    public float JumpTargetHeight = 5f;
    public float JumpTime = 0.8f;
    public float Gravity;


    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        RivalSpeed = Speed;
        Gravity = -((2 * JumpTargetHeight * transform.localScale.y / 2) / ((JumpTime / 2) * (JumpTime / 2)));
        Debug.Log(Gravity);
    }

    // Update is called once per frame
    void Update()
    {
        V3 = transform.position;

        if (IsGround.IsReady && !IsJumping)
        {
            //移動
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                Rb.AddForce(RivalSpeed * ((Vector3.left * Speed) - Rb.velocity));
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                Rb.AddForce(RivalSpeed * ((Vector3.right * Speed) - Rb.velocity));
            }

            //ジャンプ
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
            {
                //V3.y = JumpPower;
                JumpStartTime = Time.time;
                IsJumping = true;
                DefaultY = V3.y;
                //Rb.position = new Vector3(V3.x, V3.y + JumpPower * Time.deltaTime, V3.z);
            }
            else
            {

                if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.A) &&
                    !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.D))
                {
                    Rb.velocity = Vector3.zero;
                }

            }
        }
        else
        {
            if (IsJumping)
            {
                float JumpDeltaTime = Time.time - JumpStartTime;
                float y = DefaultY + -(Gravity * JumpTime / 2 * JumpDeltaTime) + 0.5f * Gravity * JumpDeltaTime * JumpDeltaTime;
                Debug.Log(y);
                Rb.position = new Vector3(V3.x, y, V3.z);
                if(JumpDeltaTime>JumpTime)
                {
                    IsJumping = false;
                }
            }
            else
            {
                V3.y -= -Gravity/5 * Time.deltaTime;
                Rb.position = V3;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        IsJumping = false;
    }
}
