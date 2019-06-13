using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject Target;
    public Vector3 PlusPos;
    Vector3 TargetPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 V3 = transform.position;
        Vector3 TargetPos = Target.transform.position;
        V3.x = TargetPos.x + PlusPos.x;
        V3.y = TargetPos.y + PlusPos.y;
        V3.z = TargetPos.z + PlusPos.z;
        transform.position = V3;
    }
}
