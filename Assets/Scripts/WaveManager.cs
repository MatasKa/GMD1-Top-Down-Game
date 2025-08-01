using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject nextWavePrompt;
    public TextMeshProUGUI waveTimer;
    public TextMeshProUGUI waveCounter;
    public ShopZone shop;
    public EnemySpawnManager enemySpawnManager;
    private float countdownTime = 45f;
    private int wave = 0;

    void Start()
    {
        nextWavePrompt.SetActive(true);
        enemySpawnManager.enabled = false;
        waveCounter.text = wave.ToString();
        waveTimer.gameObject.SetActive(false);
    }

    public void OnY()
    {
        if (enemySpawnManager.enabled == false && shop.shopScreen.activeSelf == false)
        {
            StartCoroutine(StartNextWave());
        }
    }

    public int GetWave()
    {
        return wave;
    }

    private IEnumerator StartNextWave()
    {
        wave++;
        nextWavePrompt.SetActive(false);
        waveCounter.text = wave.ToString();
        enemySpawnManager.setTimeOut(false);
        if (wave != 10)
        {
            waveTimer.gameObject.SetActive(true);
            shop.SetTimeOut(false);
            enemySpawnManager.enabled = true;
            float timeLeft = countdownTime;
            waveTimer.text = "Time left: " + timeLeft.ToString();
            while (timeLeft >= 0)
            {
                yield return new WaitForSeconds(1f);
                timeLeft -= 1f;
                waveTimer.text = "Time left: " + timeLeft.ToString();
            }
            EndWave();
        }
        else
        {
            enemySpawnManager.spawnInterval = 10f;
            shop.SetTimeOut(false);
            enemySpawnManager.enabled = true;
            enemySpawnManager.SpawnBoss();
        }
    }

    private void EndWave()
    {
        shop.SetTimeOut(true);
        enemySpawnManager.setTimeOut(true);
        nextWavePrompt.SetActive(true);
        enemySpawnManager.enabled = false;
        waveCounter.text = wave.ToString();
        waveTimer.gameObject.SetActive(false);
    }
}
