using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopPointDest : MonoBehaviour
{
    bool IsHit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsHit) Destroy(gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HitScoreBox")
        {
            Debug.Log("hit");
            IsHit = true;
        }
        //Debug.Log("hit");
    }
}
