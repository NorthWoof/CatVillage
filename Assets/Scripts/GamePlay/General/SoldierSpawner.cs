﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawner : MonoBehaviour
{
    public static SoldierSpawner Instance { get; private set; }

    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        if (!spawnPoint)
            spawnPoint = GameObject.Find("SoldierSpawnPoint").transform;
    }

    public void SpawnSoldier(GameObject soldier)
    {
        Vector3 randomSpawnPoint = new Vector3(spawnPoint.position.x, spawnPoint.position.y + Random.Range(-0.25f, 0.25f));
        GameObject tempSoldier = Instantiate(soldier, randomSpawnPoint, spawnPoint.rotation);

        SetSpriteOrder(tempSoldier);
    }

    void SetSpriteOrder(GameObject soldier)
    {
        soldier.GetComponent<DragonBones.UnityArmatureComponent>().sortingOrder = (int)(soldier.transform.position.y * -10000);
    }


}
