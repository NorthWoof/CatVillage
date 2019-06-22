using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorClass : CatController
{
    public override void Attack()
    {
        if (!target)
            return;

        base.Attack();

        //target.TakeDamage(attackDamage,DamageType.melee);
        target.TakeDamage(attackDamage);
    }
}
