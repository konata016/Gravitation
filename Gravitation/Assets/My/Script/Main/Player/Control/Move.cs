using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move : MonoBehaviour
{
    private Rigidbody Rb;

    //初速
    public float Speed = 10f;

    //マックス速度
    public float MaxSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //空中にいるときは実行しない
        if (IsGround.IsReady)
        {
                //移動
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                Rb.AddForce(MaxSpeed * ((Vector3.left * Speed) - Rb.velocity));
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                Rb.AddForce(MaxSpeed * ((Vector3.right * Speed) - Rb.velocity));
            }

            //ボタンを離したら力をなくす
            if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.A) &&
                 !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.D))
            {
                Rb.velocity = Vector3.zero;
            }

        }

    }
}
