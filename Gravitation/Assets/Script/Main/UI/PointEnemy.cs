using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PointEnemy : MonoBehaviour
{
    GameObject[] EnemyArray;
    List<bool> IsActive = new List<bool>();
    List<GameObject> PointObj = new List<GameObject>();
    List<GameObject> EnemyObj = new List<GameObject>();

    public GameObject TargetPos;
    int EnemyCount;


    [Header("向かう速度")]
    public float Speed = 10f;

    [Header("敵を倒した時に表示するテキスト")]
    public GameObject Point;

    [Header("敵を倒した時に表示する内容")]
    public float EenmyPoint = 10000f;
    public static float SetEenmyPoint
    {
        get;set;
    }

    // Start is called before the first frame update
    void Start()
    {
        int Count = 0;

        //他のスクリプトに得点を渡す用
        SetEenmyPoint= EenmyPoint;

        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in EnemyArray)
        {
            //敵情報格納
            EnemyObj.Add(Enemy);

            //ポイントのアクティブフラグの初期化
            IsActive.Add(false);

            //ポイントオブジェクトの初期位置
            Vector3 Pos = Enemy.transform.position;
            PointObj.Add(Instantiate(Point, new Vector3(Pos.x, Pos.y + 1.5f, Pos.z - 1f), Quaternion.identity));
            PointObj[Count].SetActive(false);

            Count++;
            EnemyCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float Step = Speed * Time.deltaTime;

        //敵のHPがなくなったら得点を出す
        for (int i = 0; i < EnemyCount; i++)
        {
            if (EnemyObj[i].GetComponent<EnemyHpUI>().EnemyHpGage.fillAmount <= 0.1f)
            {
                PointObj[i].SetActive(true);
                if (!IsActive[i])
                {
                    PointObj[i].transform.position = EnemyObj[i].transform.position;
                    IsActive[i] = true;
                }

            }
        }

        //得点の移動
        for (int i = 0; i < EnemyCount; i++)
        {
            PointObj[i].transform.position =
                Vector3.MoveTowards(PointObj[i].transform.position, TargetPos.transform.position, Step);

            //if (TargetPos.transform.position.x == PointObj[i].transform.position.x) Destroy(PointObj[i]);
        }
    }
}
