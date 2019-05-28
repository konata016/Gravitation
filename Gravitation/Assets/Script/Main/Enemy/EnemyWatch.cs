using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWatch : MonoBehaviour
{
    public GameObject Planet;
    public GameObject GravitationField;
    GameObject[] EnemyArray;

    [Header("敵のHPが0になるまでのかかる時間")]
    public float EnemyHpTime=5.0f;
    [Header("範囲に入った敵数だけ早くHPが減る")]
    public float TimeRatio = 1f;

    float Dis;
    float FieldSiz;

    float EnemyHp;
    float TmpEnemyHp;

    // Start is called before the first frame update
    void Start()
    {
        FieldSiz = GravitationField.transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        float HpTime = EnemyHpTime;

        //リストの作成
        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in EnemyArray)
        {
            //距離の参照
            Dis = Vector3.Distance(Enemy.transform.position, Planet.transform.position);

            //敵が範囲に入った時に処理
            if (Dis < FieldSiz)
            {
                HpTime -= TimeRatio;    //HPを減らす割合

                //敵のHPを減らす
                if (Enemy.GetComponent<EnemyHpUI>().IsPlanetCore)
                    Enemy.GetComponent<EnemyHpUI>().EnemyHpGage.fillAmount -= 1.0f / HpTime * Time.deltaTime;


                #region HP入れ替え系
                TmpEnemyHp = Enemy.GetComponent<EnemyHpUI>().EnemyHpGage.fillAmount;

                //一番減っているHPを確保
                if (EnemyHp == 0 || EnemyHp > TmpEnemyHp) EnemyHp = TmpEnemyHp;

                //一番減っているHPに合わせる
                Enemy.GetComponent<EnemyHpUI>().EnemyHpGage.fillAmount = EnemyHp;
                #endregion
            }
        }
    }
}
