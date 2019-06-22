using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowCatController : ArcherClass
{
    public override void Action()
    {
        int activeChance = Random.Range(0, 100);
        if (activeChance <= 75)
        {
            anim.Attack();
        }
        else
        {
            anim.Skill();
        }

        actionDelayCountdown = actionDelay;

    }

   
}
