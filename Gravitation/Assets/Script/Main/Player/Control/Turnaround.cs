using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnaround : MonoBehaviour
{
    Vector3 Direction = Vector3.left;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //入力した方向を向く
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) Direction = Vector3.left;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) Direction = Vector3.right;

        transform.rotation = Quaternion.LookRotation(Direction);
    }
}
