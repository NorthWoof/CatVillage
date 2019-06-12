using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    public GameObject[] earlyEnemies;
    public GameObject[] middleEnemies;
    public GameObject[] lateEnemies;

    public float spawnTime;
    public float minSpawnTime = 5f;
    public float maxSpawnTime = 10f;

    public int minSpawnAmount = 1;
    public int maxSpawnAmount = 2;

   

    public Transform spawnPoint;

    public float countTime;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        if (!spawnPoint)
            spawnPoint = GameObject.Find("EnemySpawnPoint").transform;

        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    public void Update()
    {
        if(spawnTime >= 0)
        {
            spawnTime -= Time.deltaTime;
        }
        else
        {
            SpawnEnemy(earlyEnemies[0]);
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }

    public void SpawnEnemy(GameObject enemy)
    {
        Vector3 randomSpawnPoint = new Vector3(spawnPoint.position.x, spawnPoint.position.y + Random.Range(-0.25f, 0.25f));
        GameObject tempEnemy = Instantiate(enemy, randomSpawnPoint, spawnPoint.rotation);

        SetSpriteOrder(tempEnemy);
    }

    void SetSpriteOrder(GameObject enemy)
    {
        enemy.GetComponent<DragonBones.UnityArmatureComponent>().sortingOrder = (int)(enemy.transform.position.y * -10000);
    }

}
