using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public GameObject tempCat;
    public float spawnTime = 15f;

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
            progressBar.value = (spawnTime - progressTime) / spawnTime;
        }
        else
        {
            SoldierSpawner.Instance.SpawnSoldier(tempCat);
            progressTime = spawnTime;
            progressBar.value = 0;
        }
    }
}
