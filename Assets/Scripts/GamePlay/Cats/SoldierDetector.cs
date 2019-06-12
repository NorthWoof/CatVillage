using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDetector : MonoBehaviour
{


    SoldierController soldier;

    private void Start()
    {
        soldier = this.transform.parent.GetComponent<SoldierController>();
    }

    private void FixedUpdate()
    {
        if (soldier.target)
            return;

        RaycastHit2D[] hits = Physics2D.CircleCastAll(this.transform.position, 0.5f, Vector2.right,1f);
        for (int i = 0; i < hits.Length; i++)
        {

            RaycastHit2D hit = hits[i];
            if (soldier.target)
            {
                if (soldier.target.tag == "Enemy")
                    return;
            }

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Enemy")
                {
                    soldier.target = hit.collider.GetComponent<Unit>();
                    return;
                }
                else if (hit.collider.tag == "EnemyBase")
                {
                    soldier.target = hit.collider.GetComponent<Unit>();
                    return;
                }
            }
        }
        soldier.target = null;

    }
}

    /*
    private void OnTriggerStay2D(Collider2D col)
    {
        if (soldier.target)
            return;

        if(!soldier.target && col.tag == "EnemyBase")
        {
            soldier.target = col.GetComponent<Unit>() ;
        }else if ((!soldier.target || soldier.target.tag == "EnemyBase") && col.tag == "Enemy")
        {
            soldier.target = col.GetComponent<Unit>();
        }   
    }*/

