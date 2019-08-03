using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Target;
    public bool LockDoor;
    public float Speed;

    Vector3 OpenPos, ClausePos;

    // Start is called before the first frame update
    void Start()
    {
        //子オブジェクトサイズの分だけ動かすための初期設定
        OpenPos = transform.position + (Vector3.forward * transform.GetChild(0).gameObject.transform.localScale.z);
        ClausePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float Dis = Vector3.Distance(Target.transform.position, transform.position);

        if (!LockDoor)
        {
            //ターゲットが近くなった時にドアを開ける
            if (Dis<10)
            {
                transform.position = Vector3.MoveTowards(transform.position, OpenPos, Speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, ClausePos, Speed * Time.deltaTime);
            }
        }
    }
    
}
