using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        //Vector3 Pos = transform.localPosition;
        //Pos.z -= ObjGenerator.BulletSpeed;
        //transform.localPosition = Pos;



        Destroy(gameObject, 10f);
    }
}
