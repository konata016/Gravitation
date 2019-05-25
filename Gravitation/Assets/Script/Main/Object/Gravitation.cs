using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitation : MonoBehaviour
{
    public GameObject Planet;   // 引力の発生する星
    Rigidbody rb;        //万有引力の式をアタッチするオブジェクト

    public float Speed = 30f;    //力の速度

    bool IsPlanetField;         //引力を発生させる空間に入った時に引力を発生させる判定用
    bool CheckExit;             //引力を発生させる空間から抜けたかどうかの判定用

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsPlanetField)
        {
            // 星に向かう向きの取得
            var Direction = Planet.transform.position - transform.position;

            //Planetの方向に力を加える
            rb.AddForce(Direction.normalized * Speed, ForceMode.Force);

            CheckExit = true;
        }
        else
        {
            if (CheckExit)
            {
                rb.velocity = Vector3.zero;
                CheckExit = false;
            }
        }

    }

    public void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag == "Field") IsPlanetField = true;
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Field") IsPlanetField = false;
    }
}
