using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    //public UnitData unit;
    public float progressTime;
    public Slider progressBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(progressTime >= -1)
        {
            progressTime -= Time.deltaTime;
        }
        else
        {
            //unit.Active();
            //progressTime = unit.cooldown;
        }
    }
}
