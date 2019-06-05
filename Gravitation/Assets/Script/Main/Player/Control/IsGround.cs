using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsGround : MonoBehaviour
{
    //地面に触れている場合の処理
    public bool IsReady;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Field") IsReady = true;
    }
    public void OnTriggerExit(Collider other)
    {
        //Debug.Log("地面ではない");
        if (other.gameObject.tag != "Field") IsReady = false;
    }

}
