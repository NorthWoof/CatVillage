using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateClass : CatController
{
    public override void Start()
    {
        base.Start();
        mana = 100;
        if (healthBar)
        {
            healthBar.SetManaBar(mana);
        }
    }
}
