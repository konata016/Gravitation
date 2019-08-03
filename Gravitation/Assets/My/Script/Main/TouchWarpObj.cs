using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchWarpObj : MonoBehaviour
{
    Vector3 StartPos;

    int WarpCount = 0;
    public Text Txt;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        Txt.text = "リセット数:" + WarpCount;
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
                transform.position = StartPos;
                WarpCount++;
                Txt.text = "リセット:" + WarpCount;
                break;
            default: break;
        }
    }
}
