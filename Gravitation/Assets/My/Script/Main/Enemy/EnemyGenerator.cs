using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject GravitationField;
    public GameObject Planet;
    GameObject[] EnemyArray;
    float FieldSiz;
    float EnemyHp;

    [Header("HP減少速度")]
    public float DOT;

    [Header("倒した時の得点")]
    public int Point = 100000;

    [Header("敵を倒した時に表示するテキスト")]
    public GameObject PointObject;
    [Header("テキストが向かう速度")]
    public float TextSpeed = 10f;

    [Header("敵を倒した時に表示するパーティクル")]
    public GameObject DeatParticle;

    [Header("アーチャーステータス")]
    public float ArrowSpeed;

    public static float      HpDownSpeed     { set; get; }
    public static int        EnemyPoint      { set; get; }
    public static GameObject PointObj        { set; get; }
    public static float      PTextSpeed      { set; get; }
    public static GameObject DeatEffect      { set; get; }
    public static int        FieldHitCount   { set; get; }
    public static float      ArrowInsSpeed   { set; get; }
    public static float      ArrowForth      { set; get; }


    // Start is called before the first frame update
    void Start()
    {
        //GravitationFieldの範囲
        FieldSiz = GravitationField.transform.localScale.x / 2;

        HpDownSpeed   = DOT;
        EnemyPoint    = Point;
        PointObj      = PointObject;
        PTextSpeed    = TextSpeed;
        DeatEffect    = DeatParticle;
        ArrowForth    = ArrowSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float TmpEnemyHp = 0;
        int Count = 0;

        #region HP入れ替え系
        //敵リストの作成
        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in EnemyArray)
        {
            //距離の参照
            float Dis = Vector3.Distance(Enemy.transform.position, Planet.transform.position);
            if (Dis < FieldSiz)
            {
                HpChange(Enemy, TmpEnemyHp);    //Hpの入れ替え
                Count++;                        //フィールド内に居る数
            }

        }
        #endregion

        FieldHitCount = Count;
    }

    //Hpの入れ替え
    public void HpChange(GameObject Enemy, float TmpEnemyHp)
    {
        TmpEnemyHp = Enemy.GetComponent<EnemyHpCheck>().EnemyHpGage.fillAmount;

        //一番減っているHPを確保
        if (EnemyHp == 0 || EnemyHp > TmpEnemyHp) EnemyHp = TmpEnemyHp;

        //一番減っているHPに合わせる
        Enemy.GetComponent<EnemyHpCheck>().EnemyHpGage.fillAmount = EnemyHp;
    }
   
}
