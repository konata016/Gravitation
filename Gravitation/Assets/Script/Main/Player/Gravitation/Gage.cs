using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gage : MonoBehaviour
{
    public Image GravityGage;
    public float countTime = 5.0f;

    // Update is called once per frame
    void Update()
    {
        //プレイヤーを引力の影響下における時間
        if (Input.GetMouseButton(1))
        {
            GravityGage.fillAmount -= 1.0f / countTime * Time.deltaTime;
        }
        else
        {
            GravityGage.fillAmount += 1.0f / countTime * Time.deltaTime;
        }
    }
}
