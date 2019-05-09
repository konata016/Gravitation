using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Target;
    public Vector3 V3;

    //public float Speed;
    public float SmoothTime = 0.1f;
    Vector3 Velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(new Vector3(transform.localPosition.z, 0f, 0f));

        //float Step = Speed * Time.deltaTime;

        Vector3 Pos = transform.position;

        Pos.x = Target.transform.position.x + V3.x;
        Pos.y = V3.y;
        Pos.z = Target.transform.position.z + V3.z;

        if (!Input.GetMouseButton(0))
        {
            //transform.position = Vector3.MoveTowards(transform.position, Pos, Step);
            transform.position = Vector3.SmoothDamp(transform.position, Pos, ref Velocity, SmoothTime);
        }
    }
}
