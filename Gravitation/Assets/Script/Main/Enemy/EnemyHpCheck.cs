using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpCheck : MonoBehaviour
{
    bool IsPlanetCore;
    public Image EnemyHpGage;

    // Start is called before the first frame update
    void Start()
    {
        EnemyHpGage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //プラネットコアに触れた場合Hpを減少させる
        if (IsPlanetCore)
        {
            EnemyHpGage.fillAmount -=
            EnemyGenerator.HpDownSpeed * Time.deltaTime * (EnemyGenerator.FieldHitCount / 2f);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PlanetCore") IsPlanetCore = true;
    }
    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "PlanetCore") IsPlanetCore = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Field")
        {
            // プラネットフィールドに入った場合HPを可視化する
            EnemyHpGage.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        //プラネットフィールドから出た場合
        if (other.gameObject.tag == "Field")
        {
            EnemyHpGage.gameObject.SetActive(false);
        }
    }
}
