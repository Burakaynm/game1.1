using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; //Make array for multiple enemies
    public GameObject[] buffPrefabs;
    public GameObject[] debuffPrefabs;
    public Transform spawn;
    private GameObject enemyToSpawn;
    private GameObject buffToSpawn;
    private GameObject debuffToSpawn;

    public float enemySpawnInterval;
    public float buffSpawnInterval;
    public float debuffSpawnInterval;
    private float SpawnRadius = 30f;

    private bool canSpawn = true;

    private Vector3 spawnPos;

    private void Start()
    {
        StartCoroutine(EnemySpawnwer());
        StartCoroutine(BuffSpawner());
        StartCoroutine(DebuffSpawner());

        spawnPos = spawn.transform.position;
    }
    private IEnumerator EnemySpawnwer()
    {
        if (spawn != null)
        {
            WaitForSeconds enemyWait = new WaitForSeconds(enemySpawnInterval);

            while (canSpawn)
            {
                yield return enemyWait;

                int rand = Random.Range(0, enemyPrefabs.Length);    //Select enemies to spawn
                enemyToSpawn = enemyPrefabs[rand];

                Vector3 temp = spawnPos + (Random.insideUnitSphere * SpawnRadius); //Choose random place to spawn
                temp.y = spawnPos.y;

                GameObject newEnemy = Instantiate(enemyToSpawn, temp, spawn.rotation);  //Spawn enemies

                newEnemy.SetActive(true);
            }
        }
    }
    private IEnumerator BuffSpawner()
    {
        if (spawn != null)
        {
            WaitForSeconds buffWait = new WaitForSeconds(buffSpawnInterval);

            while (canSpawn)
            {
                yield return buffWait;

                int rand = Random.Range(0, buffPrefabs.Length);    //Select enemies to spawn
                buffToSpawn = buffPrefabs[rand];

                Vector3 temp = spawnPos + (Random.insideUnitSphere * SpawnRadius); //Choose random place to spawn
                temp.y = spawnPos.y;

                //GameObject projectileObj = ObjectPool.instance.GetPooledObj(rand);
                GameObject newBuff = Instantiate(buffToSpawn, temp, spawn.rotation);  //Spawn enemies

                newBuff.SetActive(true);
            }
        }
    }
    private IEnumerator DebuffSpawner()
    {
        if (spawn != null)
        {
            WaitForSeconds debuffWait = new WaitForSeconds(debuffSpawnInterval);

            while (canSpawn)
            {
                yield return debuffWait;

                int rand = Random.Range(0, debuffPrefabs.Length);    //Select enemies to spawn
                debuffToSpawn = debuffPrefabs[rand];

                Vector3 temp = spawnPos + (Random.insideUnitSphere * SpawnRadius); //Choose random place to spawn
                temp.y = spawnPos.y;

                GameObject newDebuff = Instantiate(debuffToSpawn, temp, spawn.rotation);  //Spawn enemies

                newDebuff.SetActive(true);
            }
        }
    }

    //fonksiyonn yap
}

