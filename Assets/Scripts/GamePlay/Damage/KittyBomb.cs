using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyBomb : MonoBehaviour
{
    public int damage;
    public float damageBaseMultiplier = 1.5f;

    private void Start()
    {
        Destroy(this.gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            col.GetComponent<Unit>().TakeDamage(damage);
        }
        if(col.tag == "EnemyBase")
        {
            int newDamage = Mathf.RoundToInt(damage * damageBaseMultiplier);
            col.GetComponent<Unit>().TakeDamage(newDamage);
        }
    }
}
