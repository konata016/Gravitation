using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScripIsGround : MonoBehaviour
{
    public SphereCollider JumpManager;

    // Start is called before the first frame update
    void Start()
    {
        //スクリプトをアタッチするやつ
        JumpManager = GetComponent<SphereCollider>();
        JumpManager.gameObject.AddComponent<IsGround>();
    }

    // Update is called once per frame

    void Update()
    {
        
    }
}
