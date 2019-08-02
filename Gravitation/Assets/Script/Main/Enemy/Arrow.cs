using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float Speed;
    Rigidbody Rb;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Rb.AddForce(Speed * (Vector3.right * Speed) - Rb.velocity);
        //transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);

    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    void OnTriggerStay(Collider other)
    {
        Destroy(gameObject);
    }
}
