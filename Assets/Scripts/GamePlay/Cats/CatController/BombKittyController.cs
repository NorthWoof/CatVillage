using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombKittyController : PirateClass
{
    public KittyBomb bomb;
    public Transform bombPoint;

    public override void Action()
    {
        if(mana >= 100)
        {
            Skill();
        }
        else 
            Dead();
    }

    public override void Skill()
    {
        base.Skill();
        KittyBomb tempBomb = Instantiate(bomb, bombPoint.transform.position, bombPoint.transform.rotation);
        tempBomb.damage = attackDamage;
        Dead();
    }

    public override void Dead()
    { 
        base.Dead();
    }

}
