using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsGround : MonoBehaviour
{
    //地面に触れている場合の処理
    public bool IsReady;

    //着地した場合の処理
    //public UnityEvent OnEnterGround;
    //地面から離れた場合の処理
    //public UnityEvent OnExitGround;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("地面である");
        IsReady = true;
    }
    public void OnTriggerExit(Collider other)
    {
        Debug.Log("地面ではない");
        IsReady = false;
    }

}
