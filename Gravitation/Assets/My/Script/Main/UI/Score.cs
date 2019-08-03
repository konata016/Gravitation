using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreTxt;
    public static int ScorePoint { get; set; }
    public static int WarpCount { get; set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScoreTxt.text = "" + ScorePoint+"p";
    }

    void OnTriggerEnter(Collider other)
    {
        ScorePoint += EnemyGenerator.EnemyPoint;
    }
}
