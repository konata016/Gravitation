using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    GameObject[] EnemyArray;
    List<bool> IsParticle = new List<bool>();

    public GameObject Particle;
    int EnemyCount;

    int Wait;

    // Start is called before the first frame update
    void Start()
    {
        //敵の数分だけ配列(フラグ)を作る
        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in EnemyArray)
        {
            EnemyCount++;
            IsParticle.Add(false);
        }
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
                if (!IsParticle[Count])
                {
                    Instantiate(Particle, Enemy.transform);
                    IsParticle[Count] = true;
                }
                else IsParticle[Count] = false;
                //Destroy(Enemy, 0.1f);
                if (Wait > 10)
                {
                    Enemy.SetActive(false);
                    Wait = 0;
                }
                else Wait++;

            }
            Count++;
        }

    
    }
}
