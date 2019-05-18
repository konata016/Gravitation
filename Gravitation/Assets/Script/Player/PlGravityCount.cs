using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlGravityCount : MonoBehaviour
{
    public Image GravityGage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //スクリプトのアクティブ制御
        if (GravityGage.fillAmount > 0)
        {
            GetComponent<PlayerGravitation>().enabled = true;
        }
        else
        {
            GetComponent<PlayerGravitation>().enabled = false;
        }
    }
}
