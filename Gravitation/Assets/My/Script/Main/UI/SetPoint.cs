using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPoint : MonoBehaviour
{
    Text Txt;

    // Start is called before the first frame update
    void Start()
    {
        Txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //敵が消滅するときに得点を出す
        Txt.text = "+" + EnemyGenerator.EnemyPoint;
    }
}