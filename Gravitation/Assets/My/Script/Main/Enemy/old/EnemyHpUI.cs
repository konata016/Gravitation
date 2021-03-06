﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpUI : MonoBehaviour
{
    public Image EnemyHpGage;

    public bool IsPlanetCore;

    // Start is called before the first frame update
    void Start()
    {
        EnemyHpGage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "PlanetCore") IsPlanetCore = true;
    }
    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "PlanetCore") IsPlanetCore = false;
    }

    void OnTriggerEnter(Collider other)
    {
        //プラネットフィールドに入った場合HPを可視化する
        if (other.gameObject.tag == "Field") EnemyHpGage.gameObject.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        //プラネットフィールドから出た場合
        EnemyHpGage.gameObject.SetActive(false);
    }
}
