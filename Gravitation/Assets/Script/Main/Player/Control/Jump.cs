using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody Rb;
    public float JumpPower = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
        {
            //地面に接している場合はジャンプできる
            if (IsGround.IsReady)
            {
                Rb.velocity = transform.up * JumpPower;
            }
        }
    }


}
