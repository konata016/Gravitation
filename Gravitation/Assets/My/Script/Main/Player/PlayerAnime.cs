﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnime : MonoBehaviour
{
    private Animator Anim;
    private Rigidbody Rb;
    public float RayDis = 2f;   //Rayの長さ

    //エラーをなくすためのやつ
    public void OnCallChangeFace() { }

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //Rayの作成
        Ray ray = new Ray(transform.position, new Vector3(0, -1, 0));

        if (Input.GetButtonDown("Jump")) Anim.SetBool("Jump1", true);
        else Anim.SetBool("Jump1", false);

        //Reyにオブジェクトが当たったら着地する
        if (Physics.Raycast(ray, RayDis)) Anim.SetBool("Jump2", true);
        else Anim.SetBool("Jump2", false);


        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            Anim.SetBool("Float", false);
            if (IsGround.IsReady) Anim.SetBool("Running", true);
        }
        else
        {
            Anim.SetBool("Running", false);
            Anim.SetBool("Float", true);
        }

        //Debug.Log(message: rb.velocity.magnitude);
        //if (gameObject.GetComponent<IsGround>().IsReady)Anim.SetBool("Jump2", true);
        //else Anim.SetBool("Jump2", false);
    }
}
