using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    EnemyController enemy;

    private void Start()
    {
        enemy = this.transform.parent.GetComponent<EnemyController>();
    }

    private void FixedUpdate()
    {
        if (enemy.target)
            return;

        RaycastHit2D[] hits = Physics2D.CircleCastAll(this.transform.position, 0.5f, -Vector2.right, 1f);
        for (int i = 0; i < hits.Length; i++)
        {

            RaycastHit2D hit = hits[i];
            if (enemy.target)
            {
                if (enemy.target.tag == "Cat")
                    return;
            }

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Cat")
                {
                    enemy.target = hit.collider.GetComponent<Unit>();
                    return;
                }
                else if (hit.collider.tag == "CatBase")
                {
                    enemy.target = hit.collider.GetComponent<Unit>();
                    return;
                }
            }
        }
        enemy.target = null;

    }
    /*
    private void OnTriggerStay2D(Collider2D col)
    {
        if (enemy.target)
            return;
        if (!enemy.target && col.tag == "CatBase")
        {
            enemy.target = col.GetComponent<Unit>();
        }
        else if ((!enemy.target || enemy.target.tag == "CatBase") && col.tag == "Cat")
        {
            enemy.target = col.GetComponent<Unit>();
        }
    }*/
}
