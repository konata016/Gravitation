using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitation : MonoBehaviour
{
    public GameObject Planet;   // 引力の発生する星
    public float Coefficient;	// 万有引力係数

    public Rigidbody rb;        //万有引力の式をアタッチするオブジェクト
    public Rigidbody PlanetRb;  //引力を発生させる物体

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlanetRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 星に向かう向きの取得
        var Direction = Planet.transform.position - transform.position;
        // 星までの距離の２乗を取得
        var Distance = Direction.magnitude;
        Distance *= Distance;
        // 万有引力計算
        var gravity = Coefficient * PlanetRb.mass * rb.mass / Distance;

        // 力を与える
        rb.AddForce(gravity * Direction.normalized, ForceMode.Force);
    }
}
