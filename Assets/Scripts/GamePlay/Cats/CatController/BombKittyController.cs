using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombKittyController : SoldierController
{
    public KittyBomb bomb;
    public Transform bombPoint;

    public override void Action()
    {
        Dead();
    }

    public override void Dead()
    {
        KittyBomb tempBomb = Instantiate(bomb, bombPoint.transform.position, bombPoint.transform.rotation);
        tempBomb.damage = attackDamage;
        base.Dead();
    }

}
