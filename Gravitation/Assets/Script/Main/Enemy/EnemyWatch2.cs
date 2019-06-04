using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWatch2 : MonoBehaviour
{
    public GameObject Planet;
    public GameObject GravitationField;
    GameObject[] EnemyArray;

    [Header("敵1体のHPが0になるまでの時間")]
    public float OneHpDown = 10f;
    [Header("敵が多くなった時のHP減少速度")]
    public float HpDownSpeed = 1f;

    float Dis;
    float FieldSiz;

    float EnemyHp;
    float TmpEnemyHp;

    float HpDownTime;

    int EnemyCount;

    // Start is called before the first frame update
    void Start()
    {
        //GravitationFieldの範囲
        FieldSiz = GravitationField.transform.localScale.x / 2;

        //初期値の設定
        int Count = 0;
        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in EnemyArray)
        {
            //距離の参照
            Dis = Vector3.Distance(Enemy.transform.position, Planet.transform.position);

            //敵が範囲に入った時に処理
            if (Dis < FieldSiz) Count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int Count = 0;  //敵数のカウント用

        //敵のHPの減る速度の計算
        HpDownTime = OneHpDown / (EnemyCount * HpDownSpeed);

        //敵リストの作成
        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in EnemyArray)
        {
            //距離の参照
            Dis = Vector3.Distance(Enemy.transform.position, Planet.transform.position);

            //敵が範囲に入った時に処理
            if (Dis < FieldSiz)
            {
                Count++;

                //敵のHPを減らす
                if (Enemy.GetComponent<EnemyHpUI>().IsPlanetCore)
                    Enemy.GetComponent<EnemyHpUI>().EnemyHpGage.fillAmount -= 1.0f / HpDownTime * Time.deltaTime;

                #region HP入れ替え系
                TmpEnemyHp = Enemy.GetComponent<EnemyHpUI>().EnemyHpGage.fillAmount;

                //一番減っているHPを確保
                if (EnemyHp == 0 || EnemyHp > TmpEnemyHp) EnemyHp = TmpEnemyHp;

                //一番減っているHPに合わせる
                Enemy.GetComponent<EnemyHpUI>().EnemyHpGage.fillAmount = EnemyHp;
                #endregion
            }
        }

        //範囲に入った敵の数を格納
        EnemyCount = Count;

    }
}