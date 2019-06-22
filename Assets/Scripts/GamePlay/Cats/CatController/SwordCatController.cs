using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCatController : WarriorClass
{
    public override void Skill()
    {
        base.Skill();

        if (!target)
            return;

        target.TakeDamage(Mathf.RoundToInt(attackDamage*2.5f));
    }
}
