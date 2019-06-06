using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject Turret;
    public GameObject Bullet;

    public float WaitTime = 1f;
    float Timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        //一定の時間間隔で弾を出す
        if (Timer >= WaitTime)
        {
            Instantiate(Bullet, Turret.transform);
            Timer = 0f;
        }
    }
}
