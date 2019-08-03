using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchWarpObj : MonoBehaviour
{
    Vector3 StartPos;

    
    bool IsStart;
    public Text Txt;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "WarpObj":
            case "Enemy":
            case "Arrow":
            case "Bullet":
                transform.position = StartPos;
               Score.WarpCount++;
                Txt.text = "Reset:" + Score.WarpCount;
                break;
            default: break;
        }
    }
}
