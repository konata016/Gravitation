using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody rb;

    //着地判定
    public bool OnEnterGround { get; set; }

    public float JumpPower = 5f;

    public SphereCollider JumpManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        JumpManager = GetComponent<SphereCollider>();
        JumpManager.gameObject.AddComponent<IsGround>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Jump"))
        {
            //地面に接している場合はジャンプできる
            if (JumpManager.gameObject.GetComponent<IsGround>().IsReady)
            {
                rb.velocity = transform.up * JumpPower;

                //ジャンプしたとき着地判定を解除
                //OnEnterGround = false;
            }

            
        }
    }


}
