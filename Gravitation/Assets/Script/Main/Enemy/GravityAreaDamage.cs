using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAreaDamage : MonoBehaviour
{
    List<Enemy> Enemys = new List<Enemy>();
    public static bool IsActive { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive)
        {
            Debug.Log(IsActive);
            foreach (Enemy enemy in Enemys)
            {
                Debug.Log(enemy.tag);
                enemy.Damage(Enemys.Count, Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if(other.gameObject.tag == "Enemy")
        {
            float hp=other.gameObject.GetComponent<Enemy>().GetHp();
            foreach(Enemy enemy in Enemys)
            {
                if(hp<enemy.GetHp())
                {
                    enemy.GetComponent<Enemy>().SetHp(hp);
                }
            }
            Enemys.Add(other.gameObject.GetComponent<Enemy>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag  == "Enemy")
        {
            Enemys.Remove(other.gameObject.GetComponent<Enemy>());
            if(Enemys.Count==0)
            {
                IsActive = false;
            }
        }
    }

    public void StartDamage()
    {
        IsActive = true;
    }
}
