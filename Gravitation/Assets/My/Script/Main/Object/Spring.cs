using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    Rigidbody Rb;
    Vector3 SavePos;
    bool IsStop;
    bool IsField;

    // Start is called before the first frame update
    void Start()
    {
        Rb = gameObject.GetComponent<Rigidbody>();
        SavePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //特定の座標まで行ったらフラグを立て、ずれを正す
        if (SavePos.y - ObjGenerator.SpringMinPos > transform.position.y)
        {
            transform.position = new Vector3(SavePos.x, SavePos.y - ObjGenerator.SpringMinPos, SavePos.z);
            IsStop = true;
        }
        if (SavePos.y < transform.position.y)
        {
            transform.position = SavePos;
            IsStop = true;
        }

        //特定の座標まで行ったら力を止める
        if (IsStop)
        {
            Rb.velocity = Vector3.zero;
            GetComponent<Gravitation>().enabled = false;
            if (!IsField) IsStop = false;
        }
        if (IsField) GetComponent<Gravitation>().enabled = true;

        //ばね力
        if (SavePos.y > transform.position.y)
        {
            if (!IsField)
            {
                Rb.AddForce(Vector3.up * ObjGenerator.SpringPower, ForceMode.Acceleration);
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Field") IsField = true;
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Field") IsField = false;
    }
}
