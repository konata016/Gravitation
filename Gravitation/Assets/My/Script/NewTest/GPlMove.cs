using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPlMove : MonoBehaviour
{
    Rigidbody Rb;
    Vector3 V3;
    float RivalSpeed;
    bool IsKey;

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
                float X=Input.GetAxis("Horizontal") * Speed;
                Rb.AddForce(RivalSpeed * (new Vector3(X, 0, 0) - Rb.velocity)); 
            }
            else
            {
                float Z = Input.GetAxis("Vertical") * Speed;
                Rb.AddForce(RivalSpeed * (new Vector3(0, 0, Z) - Rb.velocity));
            }

            //慣性を消す
            if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0 && !Input.anyKey)
            {
                if (!IsKey)
                {
                    Rb.isKinematic = true;
                    IsKey = true;
                }
            }
            else IsKey = false;

            if (IsKey) Rb.isKinematic = false;
        }
    }
}
