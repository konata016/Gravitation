using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjGravity2 : MonoBehaviour
{
    Ray[] Ray_ = new Ray[3];
    Rigidbody Rb;
    Vector3 V3;
    Vector3 GroundPos;
    bool IsPlayer;
    bool IsSlip;
    bool[] MyIsGround = new bool[3];

    public GameObject TargetForward;
    public GameObject TargetDown;
    public GameObject TargetRight;
    public GameObject TargetLeft;
    public float Gravity = 200;
    public float RayLeng = 100f;

    enum Direction
    {
        Forward, Down,
        Right, Left
    }

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        V3 = transform.position;

        Ray_[(int)Direction.Forward] = new Ray(transform.position, Vector3.forward);
        Ray_[(int)Direction.Down] = new Ray(transform.position, Vector3.down);
        Ray_[(int)Direction.Right] = new Ray(transform.position, Vector3.right);
        Ray_[(int)Direction.Left] = new Ray(transform.position, Vector3.left);

        //重力
        if (Physics.Raycast(Ray_[(int)Direction.Forward], RayLeng) && !MyIsGround[(int)Direction.Forward])
        {
            Rb.AddForce(Vector3.forward * Gravity);
            Rb.position = Vector3.MoveTowards(
                transform.position, new Vector3(V3.x, TargetForward.transform.position.y, V3.z), 10);
        }
        if (Physics.Raycast(Ray_[(int)Direction.Down]) && !MyIsGround[(int)Direction.Down])
        {
            Rb.AddForce(Vector3.down * Gravity);
            Rb.position = Vector3.MoveTowards(
                transform.position, new Vector3(V3.x, V3.y, TargetDown.transform.position.z), 10);
        }
        if (Physics.Raycast(Ray_[(int)Direction.Left]) && !MyIsGround[(int)Direction.Left])
        {
            Rb.AddForce(Vector3.left * Gravity);
            Rb.position = Vector3.MoveTowards(
                transform.position, new Vector3(TargetLeft.transform.position.x, V3.y, V3.z), 10);
        }
        if (Physics.Raycast(Ray_[(int)Direction.Right]) && !MyIsGround[(int)Direction.Right])
        {
            Rb.AddForce(Vector3.right * Gravity);
            Rb.position = Vector3.MoveTowards(
                transform.position, new Vector3(TargetRight.transform.position.x, V3.y, V3.z), 10);
        }

        //移動
        if (MyIsGround[(int)Direction.Forward])
        {
            Rb.AddForce(Vector3.up * Gravity);

        }


        if (Input.GetKeyDown(KeyCode.Alpha5))
        {

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

        }



    }
    private void OnCollisionEnter(Collision collision)
    {
        //MyIsGround[(int)Direction.Forward] = false;
        //MyIsGround[(int)Direction.Down] = false;
        //MyIsGround[(int)Direction.Right] = false;
        //MyIsGround[(int)Direction.Left] = false;
        if (collision.gameObject.tag == "TargetForward") MyIsGround[(int)Direction.Forward] = true;
        if (collision.gameObject.tag == "TargetDown") MyIsGround[(int)Direction.Down] = true;
        if (collision.gameObject.tag == "TargetRight") MyIsGround[(int)Direction.Right] = true;
        if (collision.gameObject.tag == "TargetLeft") MyIsGround[(int)Direction.Left] = true;
    }
    private void OnCollisionExit(Collision collision)
    {
     
    }
}
