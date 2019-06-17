using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : Unit
{
    public override void Dead()
    {
        isDead = true;
        gameObject.layer = 10;
        Destroy(this.gameObject);
    }
}
