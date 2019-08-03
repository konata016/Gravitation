using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosFix : MonoBehaviour
{
    Rigidbody Rb;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetMouseButton(1))
        //{
        //    Rb.constraints = RigidbodyConstraints.FreezeRotation;
        //}
        //else
        //{
        //    if (IsGround.IsReady)
        //    {               
        //            Rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        //    }
        //    else
        //    {
        //        Rb.constraints = RigidbodyConstraints.FreezeRotation;
        //    }
        //}
    }
}
