using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDetector : MonoBehaviour
{
    SoldierController soldier;

    public float range = 0.75f;

    private void Start()
    {
        soldier = this.transform.parent.GetComponent<SoldierController>();

        range += Random.Range(-0.25f,0.25f);
    }

    private void FixedUpdate()
    {
        if (soldier.target)
        {
            if (soldier.target.tag == "Enemy")
                return;
        }

        RaycastHit2D[] hits = Physics2D.CircleCastAll(this.transform.position, 0.5f, Vector2.right,range);
        for (int i = 0; i < hits.Length; i++)
        {

            RaycastHit2D hit = hits[i];

            if (hit.collider != null)
            {
                if (hit.collider.tag == "EnemyBase")
                {
                    soldier.target = hit.collider.GetComponent<Unit>();
                }
                else if (hit.collider.tag == "Enemy")
                {
                    if (!hit.collider.GetComponent<Unit>().isDead)
                    {
                        soldier.target = hit.collider.GetComponent<Unit>();
                        return;
                    }
                }
            }
        }
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

