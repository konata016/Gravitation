using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gage : MonoBehaviour
{
    public Image UIobj;
    public bool roop;
    public float countTime = 5.0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            UIobj.fillAmount -= 1.0f / countTime * Time.deltaTime;
        }
        else
        {
            UIobj.fillAmount += 1.0f / countTime * Time.deltaTime;
        }

    }
}
