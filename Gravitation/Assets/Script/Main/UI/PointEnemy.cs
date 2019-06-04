using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointEnemy : MonoBehaviour
{
    GameObject[] EnemyArray;
    Vector3 Velocity;
    List<GameObject> PointObj = new List<GameObject>();
    List<GameObject> EnemyObj = new List<GameObject>();

    public Camera Cam;
    public GameObject TargetPos;
    int EnemyCount;


    [Header("向かうまでの時間")]
    public float SmoothTime = 1.5f;

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

        //敵の数分だけ配列(フラグ)を作る
        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in EnemyArray)
        {
            EnemyObj.Add(Enemy);

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
        //敵のHPがなくなったら得点を出す
        for(int i = 0; i < EnemyCount; i++)
        {
            if (EnemyObj[i].GetComponent<EnemyHpUI>().EnemyHpGage.fillAmount <= 0.1f)
            {
                PointObj[i].transform.position = EnemyObj[i].transform.position;
                PointObj[i].SetActive(true);
            }
        }


        //作ったポイントオブジェクトのリスト作成
        //PointObj = GameObject.FindGameObjectsWithTag("PopUpPoint");
        //foreach (GameObject PopUpPoint in PointObj)
        //{
        //    //画面右上取得
        //    Vector3 Pos = RectTransformUtility.WorldToScreenPoint(Cam,Vector3.zero);
        //    //Pos.Scale(new Vector3(-1f, 3.5f, 1f));

        //    //画面右上まで行く
        //    //PopUpPoint.transform.position = Vector3.MoveTowards(PopUpPoint.transform.position, Pos, Step);
        //    PopUpPoint.transform.position =
        //    Vector3.SmoothDamp(PopUpPoint.transform.position, Pos, ref Velocity, SmoothTime);

        //    //目標地点まで行ったときにテキストを消す
        //    //if (Pos.x == PopUpPoint.transform.position.x) Destroy(PopUpPoint);
        //}
    }
}
