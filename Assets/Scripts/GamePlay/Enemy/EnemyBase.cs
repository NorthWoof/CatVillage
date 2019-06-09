using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int hp = 20;
    public int attackDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        CheckHp();
    }

    public void CheckHp()
    {
        if(hp <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        gameObject.layer = 10;
        Destroy(this.gameObject);
    }
}
