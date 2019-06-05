using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreTxt;
    int ScorePoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScoreTxt.text = "" + ScorePoint;
    }

    void OnTriggerEnter(Collider other)
    {
        ScorePoint += EnemyGenerator.EnemyPoint;
    }
}
