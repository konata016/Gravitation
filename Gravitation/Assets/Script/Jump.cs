using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody rb;

    public float JumpPower = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
        {
            //地面に接している場合はジャンプできる
            if (gameObject.GetComponent<IsGround>().IsReady)
            {
                rb.velocity = transform.up * JumpPower;
            }
        }
    }


}
