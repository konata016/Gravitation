using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpPoint : MonoBehaviour
{
    Text Txt;
    public PointEnemy s;

    // Start is called before the first frame update
    void Start()
    {
        Txt = GetComponent<Text>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Txt.text = "+" + s.EenmyPoint;
    }
}
