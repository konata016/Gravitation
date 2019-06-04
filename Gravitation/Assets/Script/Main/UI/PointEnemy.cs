using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointEnemy : MonoBehaviour
{
    GameObject[] EnemyArray;
    GameObject[] PopUpScore;

    public GameObject Point;

    public float EenmyPoint = 10000f;

    List<bool> FrgS = new List<bool>();

    // Start is called before the first frame update
    void Start()
    {
        //敵の数分だけ配列(フラグ)を作る
        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in EnemyArray) FrgS.Add(false);
    }

    // Update is called once per frame
    void Update()
    {
        int Count = 0;

        //敵リストの作成
        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in EnemyArray)
        {
            //敵のHPが0.1を切ったらエフェクトを出し、敵を消す
            if (Enemy.GetComponent<EnemyHpUI>().EnemyHpGage.fillAmount <= 0.1f)
            {
                    Instantiate(Point, Enemy.transform);
            }
            Count++;
        }
    }
}
