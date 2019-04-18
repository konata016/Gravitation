using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed = 1f;

    //着地判定
    public bool OnEnterGround { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward * Speed, ForceMode.Impulse);
        }


        //地面に接しているとき
        if (OnEnterGround)
        {
            //慣性を消す
            rb.velocity = Vector3.zero;
        }

    }
}
