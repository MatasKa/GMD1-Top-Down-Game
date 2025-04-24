using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnInterval = 5f;
    private GameObject[] SpawnPoints;
    private bool[] IsSpawnDisabled = new bool[9];
    private List<int> EnabledSpawnIndex = new List<int>();
    void Start()
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawn");
        InvokeRepeating("SpawnEnemy", 5f, spawnInterval);
        Debug.Log("Spawn Script Started");
    }

    void SpawnEnemy()
    {
        Debug.Log("SpawnEnemy Function start");
        int EnemyNumber = Random.Range(0, 5);
        Debug.Log("Random range: " + EnemyNumber);
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            Debug.Log("Spawn point " + i + " " + SpawnPoints[i].GetComponent<EnemySpawn>().IsPlayerClose());
            IsSpawnDisabled[i] = SpawnPoints[i].GetComponent<EnemySpawn>().IsPlayerClose();
            Debug.Log("Spawn point " + i + " is " + IsSpawnDisabled[i]);
            if (IsSpawnDisabled[i] == false)
            {
                EnabledSpawnIndex.Add(i);
            }
        }
        if (EnabledSpawnIndex.Count != 0)
        {
            int randomIndex = EnabledSpawnIndex[Random.Range(0, EnabledSpawnIndex.Count)];
            GameObject chosenSpawnPoint = SpawnPoints[randomIndex];

            Debug.Log("Spawning at: " + chosenSpawnPoint.name);

            Instantiate(enemyPrefabs[EnemyNumber], chosenSpawnPoint.transform.position, Quaternion.identity);
        }
        EnabledSpawnIndex.Clear();
    }
}