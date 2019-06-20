using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowCatController : SoldierController
{
    public Transform firePoint;
    public Arrow arrow;

    public override void Attack()
    {
        if (!target)
            return;
        if (arrow)
        {
            Arrow tempArrow;
            if (firePoint)
                tempArrow = Instantiate(arrow, firePoint.position, firePoint.rotation);
            else
                tempArrow = Instantiate(arrow, this.transform.position, this.transform.rotation);
            tempArrow.SetValue(target.gameObject, baseAttackDamage);
        }
    }
}
