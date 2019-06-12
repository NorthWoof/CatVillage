using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatSpawnButton : MonoBehaviour
{
    public GameObject tempCat;
    public float cooldown = 15f;

    public float cooldownTime;
    public Image cooldownProgress;
    //public Slider progressBar;

    public bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
            return;

        if(cooldownTime >= 0)
        {
            cooldownTime -= Time.deltaTime;
            cooldownProgress.fillAmount = 1 - (cooldown - cooldownTime) / cooldown;
        }
        else
        {   
            cooldownTime = cooldown;
            isReady = true;
            //progressBar.value = 0;
        }
    }

    public void SpawnCat()
    {
        if (!isReady)
            return;

        SoldierSpawner.Instance.SpawnSoldier(tempCat);
        isReady = false;
    }
}
