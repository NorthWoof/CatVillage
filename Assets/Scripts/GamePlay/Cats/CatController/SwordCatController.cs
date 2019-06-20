using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCatController : SoldierController
{
    public override void Skill()
    {
        base.Skill();

        if (!target)
            return;

        //target.TakeDamage(attackDamage,DamageType.melee);
        target.TakeDamage(Mathf.RoundToInt(attackDamage*2.5f));
    }
}
