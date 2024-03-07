using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; //Make array for multiple enemies
    public Transform spawn;
    private GameObject enemyToSpawn;

    public float spawnInterval = 2f;
    private float SpawnRadius = 30f;

    private bool canSpawn = true;

    private Vector3 spawnPos;

    private void Start()
    {
        StartCoroutine(Spawner());
        spawnPos = spawn.transform.position;
    }

    private IEnumerator Spawner()
    {
        if (spawn != null)
        {
            WaitForSeconds wait = new WaitForSeconds(spawnInterval);

            while (canSpawn)
            {
                yield return wait;

                int rand = Random.Range(0, enemyPrefabs.Length);    //Select enemies to spawn
                enemyToSpawn = enemyPrefabs[rand];

                Vector3 temp = spawnPos + (Random.insideUnitSphere * SpawnRadius); //Choose random place to spawn
                temp.y = spawnPos.y;

                GameObject newEnemy = Instantiate(enemyToSpawn, temp, spawn.rotation);  //Spawn enemies

                newEnemy.SetActive(true);

            }
        }

    }

}

