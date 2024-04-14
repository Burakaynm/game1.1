using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; 
    public GameObject[] buffPrefabs;
    public GameObject[] debuffPrefabs;
    public Transform spawn;
    private GameObject toSpawn;

    public float enemySpawnInterval;
    public float buffSpawnInterval;
    public float debuffSpawnInterval;
    private float spawnInterval = 0;
    private float SpawnRadius = 30f;
    private int levelCount = 1;

    private bool canSpawn = true;

    private Vector3 spawnPos;

    private void Start()
    {
        //StartCoroutine(EnemySpawnwer(enemyPrefabs, 0));
        StartCoroutine(BuffSpawner(buffPrefabs, 1));
        //StartCoroutine(DebuffSpawner(debuffPrefabs,1));

        spawnPos = spawn.transform.position;
    }

    private void Update()
    {
        spawnInterval += Time.deltaTime;
        if(spawnInterval > enemySpawnInterval)
        {
            SpawnAmount(enemyPrefabs, 0, levelCount);
            levelCount++;
            enemySpawnInterval += levelCount;
            spawnInterval = 0;
        }
    }

    //private IEnumerator EnemySpawnwer(GameObject[] prefab, float spawnY)
    //{
    //    if (spawn)
    //    {
    //        while (canSpawn)
    //        {
    //            WaitForSeconds enemyWait = new WaitForSeconds(enemySpawnInterval);

    //            yield return enemyWait;

    //            SpawnAmount(prefab, spawnY,levelCount);
    //            levelCount++;

    //        }
    //    }
    //}
    private IEnumerator BuffSpawner(GameObject[] prefab, float spawnY)
    {
        if (spawn != null)
        {
            WaitForSeconds buffWait = new WaitForSeconds(buffSpawnInterval);

            while (canSpawn)
            {
                yield return buffWait;

                Spawn(prefab, spawnY);
            }
        }
    }
    //private IEnumerator DebuffSpawner(GameObject[] prefab, float spawnY)
    //{
    //    if (spawn != null)
    //    {
    //        WaitForSeconds debuffWait = new WaitForSeconds(debuffSpawnInterval);

    //        while (canSpawn)
    //        {
    //            yield return debuffWait;

    //            Spawn(prefab, spawnY);
    //        }
    //    }
    //}

    private void Spawn(GameObject[] prefab, float spawnY)
    {
        int rand = Random.Range(0, prefab.Length);    //Select enemies to spawn
        toSpawn = prefab[rand];

        Vector3 temp = spawnPos + (Random.insideUnitSphere * SpawnRadius); //Choose random place to spawn
        temp.y = spawnY;

        GameObject newPrefab = Instantiate(toSpawn, temp, spawn.rotation);  //Spawn enemies

        newPrefab.SetActive(true);
    }

    private void SpawnAmount(GameObject[] prefab, float spawnY, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Spawn(prefab, spawnY);
        }
    }
}

