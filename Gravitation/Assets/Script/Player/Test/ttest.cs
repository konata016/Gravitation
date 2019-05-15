using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ttest : MonoBehaviour
{
    private Animator Anim;

    public float RayDis = 2f;   //Rayの長さ

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rayの作成
        Ray ray = new Ray(transform.position, new Vector3(0, -1, 0));

        if (Input.GetButtonDown("Jump")) Anim.SetBool("Jump1", true);
        else Anim.SetBool("Jump1", false);

        //Reyにオブジェクトが当たったら着地する
        if (Physics.Raycast(ray, RayDis)) Anim.SetBool("Jump2", true);
        else Anim.SetBool("Jump2", false);


        //if (gameObject.GetComponent<IsGround>().IsReady)Anim.SetBool("Jump2", true);
        //else Anim.SetBool("Jump2", false);
    }
}
