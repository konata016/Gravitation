﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjGenerator : MonoBehaviour
{
    [Header("ジャンプ台")]
    public float SpringMinPosition;
    public float SpringJumpPower;

    [Header("大砲")]
    public float CannonBulletSpeed;
    public float CannonBulletWaitTime;

    [Header("壊れるブロック")]
    public float BreakObjectHp;

    public static float SpringMinPos    { set; get; }
    public static float SpringPower     { set; get; }
    public static float BulletSpeed     { set; get; }
    public static float BulletWaitTime  { set; get; }
    public static float BreakObjHp      { set; get; }

    // Start is called before the first frame update
    void Start()
    {
        SpringMinPos    = SpringMinPosition;
        SpringPower     = SpringJumpPower;
        BulletSpeed     = CannonBulletSpeed;
        BulletWaitTime  = CannonBulletWaitTime;
        BreakObjHp      = BreakObjectHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
