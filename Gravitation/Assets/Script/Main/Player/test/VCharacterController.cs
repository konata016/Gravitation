using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//空中で移動向きを変えられるバージョン

public class VCharacterController : MonoBehaviour
{
    public float Speed = 5;
    public float JumpPower = 5;
    public float Gravity = 10;
    Vector3 V3;
    Vector3 Direction;
    CharacterController CharCon;

    // Start is called before the first frame update
    void Start()
    {
        CharCon = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //地面に居る時
        if (CharCon.isGrounded)
        {
            //移動
            if (Input.GetKey(KeyCode.A)) CharCon.SimpleMove(Vector3.left * Speed);
            if (Input.GetKey(KeyCode.D)) CharCon.SimpleMove(Vector3.right * Speed);

            //ジャンプ
            if (Input.GetButton("Jump")) V3.y = JumpPower;

            //慣性フラグの初期化
            V3 = Vector3.zero;
            Direction = Vector3.zero;
        }
        else
        {
            //慣性及び空中移動向き変更
            if (Input.GetKey(KeyCode.A)) Direction = Vector3.left;
            if (Input.GetKey(KeyCode.D)) Direction = Vector3.right;
            if (Direction == Vector3.left) V3.x = -Speed;
            if (Direction == Vector3.right) V3.x = Speed;

            //重力
            V3.y -= Gravity * Time.deltaTime;
        }

        //慣性系の移動処理
        CharCon.Move(V3 * Time.deltaTime);
    }
}
