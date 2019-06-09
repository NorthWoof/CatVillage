using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDetector : MonoBehaviour
{
    SoldierBase soldier;

    private void Start()
    {
        soldier = this.transform.parent.GetComponent<SoldierBase>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!soldier.target && col.tag == "DarkGate")
        {
            soldier.target = col.gameObject;
        }else if ((!soldier.target || soldier.target.tag == "DarkGate")&& col.tag == "Enemy")
        {
            soldier.target = col.gameObject;
        }   
    }
}
