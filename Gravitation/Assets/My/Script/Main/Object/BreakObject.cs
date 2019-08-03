using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakObject : MonoBehaviour
{
    public Image ObjHpGage;

    float SaveHp;

    // Start is called before the first frame update
    void Start()
    {
        ObjHpGage.gameObject.SetActive(false);
        SaveHp = ObjGenerator.BreakObjHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            //弾が触れたらライフをアクティブに
            ObjHpGage.gameObject.SetActive(true);

            //Hpを減らす
            ObjGenerator.BreakObjHp--;
            float Hp = NumChange(ObjGenerator.BreakObjHp, 0f, SaveHp, 0f, 1f);
            ObjHpGage.fillAmount = Hp;

            //Hpが0の時破壊する
            if (ObjHpGage.fillAmount == 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    //数値をある範囲から別の範囲に変換する
    float NumChange(float Value, float Start1, float Stop1, float Start2, float Stop2)
    {
        return Start2 + (Stop2 - Start2) * ((Value - Start1) / (Stop1 - Start1));
    }
}
