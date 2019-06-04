﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    GameObject[] EnemyArray;

    public GameObject Particle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //敵リストの作成
        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in EnemyArray)
        {
            //敵のHPが0.1を切ったらエフェクトを出し、敵を消す
            if (Enemy.GetComponent<EnemyHpUI>().EnemyHpGage.fillAmount <= 0.1f)
            {
                //Instantiate(Particle, Enemy.transform);
                //Destroy(Enemy, 0.2f);
            }
        }
    }
}
