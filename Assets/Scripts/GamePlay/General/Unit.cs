using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int hp = 50;

    [HideInInspector] public bool isDead = false;

    public virtual void TakeDamage(int damage)
    {
        hp -= damage;
        CheckHp();
    }

    public virtual void TakeDamage(int damage,string damageType)
    {
        hp -= damage;
        CheckHp();
    }

    public void CheckHp()
    {
        if (hp <= 0)
        {
            Dead();
        }
    }

    public virtual void Dead()
    {
        isDead = true;
        gameObject.layer = 10;
        Destroy(this.gameObject, 3f);
    }
}
