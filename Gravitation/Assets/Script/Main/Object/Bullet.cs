using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody Rb;
    float MaxSpeed;
    bool IsPlanetField;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //移動
        Vector3 Pos = transform.localPosition;
        Pos.z -= ObjGenerator.BulletSpeed;
        transform.localPosition = Pos;

        //5秒後にオブジェクトを壊す
        Destroy(gameObject, 5f);
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Field") IsPlanetField = true;
    }
}
