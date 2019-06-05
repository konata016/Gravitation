using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemDest : MonoBehaviour
{
    public Image EnemyHpGage;
    public GameObject TargetPos;

    GameObject InstantText;
    bool IsLost;
    int Wait;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Step = EnemyGenerator.PTextSpeed * Time.deltaTime;

        if (EnemyHpGage.fillAmount <= 0f)
        {
            if (!IsLost)
            {
                //パーティクルの表示;
                Instantiate(EnemyGenerator.DeatEffect, transform);

                //得点を表示
                Vector3 Pos = transform.position;
                InstantText = Instantiate(EnemyGenerator.PointObj, new Vector3(Pos.x, Pos.y + 1.5f, Pos.z - 1f), Quaternion.identity) as GameObject;

                IsLost = true;
            }
            else
            {
                //テキストが消えたらオブジェクトも消す
                if (InstantText == null) Destroy(gameObject);
                else
                {
                    if (Wait > 15)
                    {
                        //得点の移動
                        InstantText.transform.position =
                            Vector3.MoveTowards(InstantText.transform.position, TargetPos.transform.position, Step);
                    }
                    else Wait++;
                }

                //完全にオブジェクトを消すとスクリプトも消えてしまうため
                //メッシュだけ消し、あとからオブジェクトを消す
                Destroy(gameObject.GetComponent<MeshRenderer>());
                Destroy(gameObject.GetComponent<Gravitation>());
                Destroy(gameObject.GetComponent<CapsuleCollider>());
            }
        }
    }
}
