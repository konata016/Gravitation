using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody Rb;
    float Timer;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //一度力を加える
        if (Timer < 0.05f)
        {
            Timer += 0.1f * Time.deltaTime;
            Rb.AddForce(EnemyGenerator.ArrowForth * (Vector3.right * EnemyGenerator.ArrowForth) - Rb.velocity);
        }

        //回転に制限をかける
        if (transform.rotation.eulerAngles.z < 280)
        {
            Rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

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
