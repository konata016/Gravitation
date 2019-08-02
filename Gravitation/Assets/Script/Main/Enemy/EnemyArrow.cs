
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    public GameObject Arrow;
    public float InstantTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Instant", 1f, InstantTime);
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
