using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBase : Unit
{
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        CatBaseHealthBar.Instance.SetHPBar(hp,maxHP);
    }

    public override void Dead()
    {
        isDead = true;
        gameObject.layer = 10;
        Destroy(this.gameObject);
    }

    public void GameOver()
    {

    }
}
