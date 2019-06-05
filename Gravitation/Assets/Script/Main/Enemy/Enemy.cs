using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float DOT;
    EnemyHpUI HpUI;

    // Start is called before the first frame update
    void Start()
    {
        GameDirector gameDirector= new GameDirector();
        DOT = gameDirector.EnemyBaseDOT;
        HpUI = GetComponent<EnemyHpUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int EnemyAmount,float time)
    {
        HpUI.EnemyHpGage.fillAmount -= DOT * time * (EnemyAmount / 2f);
        Debug.Log(HpUI.EnemyHpGage.fillAmount);
    }

    public void SetHp(float Hp)
    {
        HpUI.EnemyHpGage.fillAmount = Hp;
    }

    public float GetHp()
    {
        return HpUI.EnemyHpGage.fillAmount;
    }
}
