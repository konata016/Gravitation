﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;

    //初速
    public float Speed = 1f;

    //マックス速度
    public float MaxSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //空中にいるときは実行しない
        if (gameObject.GetComponent<IsGround>().IsReady)
        {
            //移動
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                rb.AddForce(MaxSpeed * ((Vector3.left * Speed) - rb.velocity));
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                rb.AddForce(MaxSpeed * ((Vector3.right * Speed) - rb.velocity));
            }
        }

    }
}