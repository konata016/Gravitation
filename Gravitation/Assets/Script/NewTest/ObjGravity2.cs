using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjGravity2 : MonoBehaviour
{
    Ray[] Ray_ = new Ray[4];
    Rigidbody Rb;

    Vector3[] WorldGroundPos = new Vector3[4];
    Vector3 TargetForward;
    Vector3 TargetDown;
    Vector3 TargetRight;
    Vector3 TargetLeft;
    Vector3 PowerDirec;

    int GravityDirec;
    int HitRay;
    bool[] MyIsGround = new bool[4];
    bool IsObjGround;
    bool Frg;

    public float Gravity = 200f;
    public float RayLeng = 100f;
    public float MovePower = 60f;

    enum Direction
    {
        Forward, Down,
        Right, Left
    }

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        WorldGroundPos[(int)Direction.Forward] = Vector3.zero;
        WorldGroundPos[(int)Direction.Down] = Vector3.zero;
        WorldGroundPos[(int)Direction.Right] = Vector3.zero;
        WorldGroundPos[(int)Direction.Left] = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 V3 = transform.position;
        RaycastHit Hit;
        int Count = 0;

        //レイ作成
        Ray_[(int)Direction.Forward] = new Ray(transform.position, Vector3.forward);
        Ray_[(int)Direction.Down] = new Ray(transform.position, Vector3.down);
        Ray_[(int)Direction.Right] = new Ray(transform.position, Vector3.right);
        Ray_[(int)Direction.Left] = new Ray(transform.position, Vector3.left);

        //レイに当たったオブジェクト格納
        if (Physics.Raycast(Ray_[(int)Direction.Forward], out Hit, RayLeng)) WorldGroundPos[(int)Direction.Forward] = Hit.transform.position;
        if (Physics.Raycast(Ray_[(int)Direction.Down], out Hit, RayLeng)) WorldGroundPos[(int)Direction.Down] = Hit.transform.position;
        if (Physics.Raycast(Ray_[(int)Direction.Right], out Hit, RayLeng)) WorldGroundPos[(int)Direction.Right] = Hit.transform.position;
        if (Physics.Raycast(Ray_[(int)Direction.Left], out Hit, RayLeng)) WorldGroundPos[(int)Direction.Left] = Hit.transform.position;
        TargetForward = WorldGroundPos[(int)Direction.Forward];
        TargetDown = WorldGroundPos[(int)Direction.Down];
        TargetRight = WorldGroundPos[(int)Direction.Right];
        TargetLeft = WorldGroundPos[(int)Direction.Left];


        if (IsObjGround)
        {
            //移動速度、位置代入
            if (Input.GetKeyDown(KeyCode.Alpha5) && !MyIsGround[(int)Direction.Forward])
            {
                GravityDirec = (int)Direction.Forward;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && !MyIsGround[(int)Direction.Down])
            {
                GravityDirec = (int)Direction.Down;
            }
            if (Input.GetKeyDown(KeyCode.Alpha6) && !MyIsGround[(int)Direction.Right])
            {
                GravityDirec = (int)Direction.Right;
            }

            if (Input.GetKeyDown(KeyCode.Alpha5) ||
                Input.GetKeyDown(KeyCode.Alpha2) ||
                Input.GetKeyDown(KeyCode.Alpha6))
            {
                if (MyIsGround[(int)Direction.Forward]) PowerDirec = Vector3.back * MovePower;
                if (MyIsGround[(int)Direction.Down]) PowerDirec = Vector3.up * MovePower;
                if (MyIsGround[(int)Direction.Right]) PowerDirec = Vector3.left * MovePower;
            }
        }
        else
        {
            //重力
            if (Physics.Raycast(Ray_[(int)Direction.Forward], RayLeng) && GravityDirec == (int)Direction.Forward)
            {
                if (!Frg)
                {
                    //慣性の消去
                    Rb.velocity = Vector3.zero;
                    PowerDirec = Vector3.zero;
                    Frg = true;
                }
                Rb.AddForce(Vector3.forward * Gravity);
                Rb.position = Vector3.MoveTowards(
                    transform.position, new Vector3(V3.x, TargetForward.y, V3.z), 10);
            }
            if (Physics.Raycast(Ray_[(int)Direction.Down], RayLeng) && GravityDirec == (int)Direction.Down)
            {
                if (!Frg)
                {
                    //慣性の消去
                    Rb.velocity = Vector3.zero;
                    PowerDirec = Vector3.zero;
                    Frg = true;
                }
                Rb.AddForce(Vector3.down * Gravity);
                Rb.position = Vector3.MoveTowards(
                    transform.position, new Vector3(V3.x, V3.y, TargetDown.z), 10);
            }
            //if (Physics.Raycast(Ray_[(int)Direction.Left], RayLeng))
            //{
            //    Rb.AddForce(Vector3.left * Gravity);
            //    Rb.position = Vector3.MoveTowards(
            //        transform.position, new Vector3(TargetRight.x, V3.y, V3.z), 10);
            //}
            if (Physics.Raycast(Ray_[(int)Direction.Right], RayLeng) && GravityDirec == (int)Direction.Right)
            {
                if (!Frg)
                {
                    //慣性の消去
                    Rb.velocity = Vector3.zero;
                    PowerDirec = Vector3.zero;
                    Frg = true;
                }
                Rb.AddForce(Vector3.right * Gravity);
                Rb.position = Vector3.MoveTowards(
                    transform.position, new Vector3(V3.x, TargetRight.y, V3.z), 10);
            }
        }

        //移動処理
        Rb.AddForce(PowerDirec);



    }
    private void OnCollisionEnter(Collision collision)
    {
        Frg = false;
        IsObjGround = true;
        MyIsGround[(int)Direction.Forward] = false;
        MyIsGround[(int)Direction.Down] = false;
        MyIsGround[(int)Direction.Right] = false;
        MyIsGround[(int)Direction.Left] = false;
        if (collision.gameObject.tag == "TargetForward") MyIsGround[(int)Direction.Forward] = true;
        if (collision.gameObject.tag == "TargetDown") MyIsGround[(int)Direction.Down] = true;
        if (collision.gameObject.tag == "TargetRight") MyIsGround[(int)Direction.Right] = true;
        if (collision.gameObject.tag == "TargetLeft") MyIsGround[(int)Direction.Left] = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        IsObjGround = false;
    }
}
