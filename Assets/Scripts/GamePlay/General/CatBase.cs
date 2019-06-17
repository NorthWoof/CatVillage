using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBase : Unit
{
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
