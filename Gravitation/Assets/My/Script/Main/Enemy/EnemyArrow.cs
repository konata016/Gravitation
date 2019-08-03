
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    public GameObject Arrow;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Instant", 1f, 2f);
        //GameObject Obj = Instantiate(Arrow, transform) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Instant()
    {
        GameObject Obj = Instantiate(Arrow, transform) as GameObject;
    }
}
