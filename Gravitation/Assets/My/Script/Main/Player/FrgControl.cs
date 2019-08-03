using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrgControl : MonoBehaviour
{
    public Door KeyDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            KeyDoor.LockDoor = false;
            Destroy(collision.gameObject, 0.1f);
        }
    }
}
