using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPlMove : MonoBehaviour
{
    Rigidbody Rb;
    Vector3 V3;
    float RivalSpeed;

    public float Speed;

    enum GravityDirec
    {
        Forward, Down,
        Right, Left
    }

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
            //移動
            if (PlGravityControl.RollChuck == (int)GravityDirec.Forward ||
                PlGravityControl.RollChuck == (int)GravityDirec.Down)
            {
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    Rb.AddForce(RivalSpeed * ((Vector3.left * Speed) - Rb.velocity));
                }
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    Rb.AddForce(RivalSpeed * ((Vector3.right * Speed) - Rb.velocity));
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                {
                    Rb.AddForce(RivalSpeed * ((Vector3.forward * Speed) - Rb.velocity));
                }
                if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                {
                    Rb.AddForce(RivalSpeed * ((Vector3.back * Speed) - Rb.velocity));
                }
            }

            //慣性を消す
            if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.A) &&
                    !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.D))
            {
                Rb.velocity = new Vector3(0, Rb.velocity.y, 0);
            }
        }
    }
}
