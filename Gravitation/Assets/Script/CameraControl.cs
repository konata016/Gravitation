using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(transform.localPosition.z, 0f, 0f));
        //transform.rotation = Quaternion.LookRotation(Vector3.forward,Target.transform.position);

        Vector3 pos = transform.position;

        pos.x = Target.transform.position.x;
        pos.y = Target.transform.position.y + 4;
        pos.z = Target.transform.position.z - 6;
        transform.position = pos;
    }
}
