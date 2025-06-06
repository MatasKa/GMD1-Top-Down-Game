using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject boss;
    public WaveManager waveManager;
    public float spawnInterval = 5f;
    private GameObject[] SpawnPoints;
    private bool[] IsSpawnDisabled = new bool[9];
    private List<int> EnabledSpawnIndex = new List<int>();
    private bool timeOut = true;
    void Start()
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawn");
        InvokeRepeating("SpawnEnemy", 5f, spawnInterval);
        //Debug.Log("Spawn Script Started");
    }

    public void setTimeOut(bool to)
    {
        timeOut = to;
    }
    void SpawnEnemy()
    {
        if (timeOut == false)
        {
            int maxRange;
            if ((waveManager.GetWave() / 2) + 1 == 6)
            {
                maxRange = 5;
            }
            else
            {
                maxRange = (waveManager.GetWave() / 2) + 1;
            }

            int EnemyNumber = Random.Range(0, maxRange);
            for (int i = 0; i < SpawnPoints.Length; i++)
            {
                IsSpawnDisabled[i] = SpawnPoints[i].GetComponent<EnemySpawn>().IsPlayerClose();
                if (IsSpawnDisabled[i] == false)
                {
                    EnabledSpawnIndex.Add(i);
                }
            }
            if (EnabledSpawnIndex.Count != 0)
            {
                int randomIndex = EnabledSpawnIndex[Random.Range(0, EnabledSpawnIndex.Count)];
                GameObject chosenSpawnPoint = SpawnPoints[randomIndex];

                Instantiate(enemyPrefabs[EnemyNumber], chosenSpawnPoint.transform.position, Quaternion.identity);
            }
            EnabledSpawnIndex.Clear();
        }
    }

    public void SpawnBoss()
    {
        boss.SetActive(true);
    }
}