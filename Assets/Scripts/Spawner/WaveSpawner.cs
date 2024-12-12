using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[System.Serializable]

public class Wave
{
    public string WaveName;
    public int NoOfEnemies;
    public GameObject[] EnemyTypes;
    public float Interval;
}
public class WaveSpawner : MonoBehaviour
{
    public Wave[] Waves;
    public Transform[] SpawnerPoints;
    public Timer timer;
    public TextMeshProUGUI waveName;
    public GameObject PowerSelectionMenu;
    public GameObject completeGameMenu;
    private Wave CurrentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;
    private bool canspawn = true;
    public static int WaveCounter = 1;
    public static bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        waveName.text = Waves[currentWaveNumber].WaveName;
        CurrentWave = Waves[currentWaveNumber];
        spawnWave();
        GameObject[] totalEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        if(totalEnemy.Length <= 0 && !canspawn && currentWaveNumber+1 != Waves.Length) // fungsi untuk membuat wave selanjutnya
        { 
            waveName.text = Waves[currentWaveNumber + 1].WaveName;
            if(WaveCounter == 10)
            {
                Pause(); // setiap 10 wave di pause
            }
            else
            {
                WaveCounter++;
                spawnNextWave();
            }


        }

        if (totalEnemy.Length <= 0 && !canspawn && currentWaveNumber + 1 == Waves.Length)
        {
            gameComplete();
        }
    }

    void spawnWave() // function untuk spawn musuh
    {
        if(canspawn && nextSpawnTime < Time.time)
        {
            GameObject randenemy = CurrentWave.EnemyTypes[Random.Range(0, CurrentWave.EnemyTypes.Length)];
            Transform randompoint = SpawnerPoints[Random.Range(0, SpawnerPoints.Length)];
            Instantiate(randenemy, randompoint.position, Quaternion.identity);
            CurrentWave.NoOfEnemies--;
            nextSpawnTime = Time.time + CurrentWave.Interval;
            if(CurrentWave.NoOfEnemies <= 0) // jika musuh dalam wave n habis maka tidak bisa spawn lagi
            {
                canspawn = false;
            }
        }
        
    }

    void spawnNextWave()
    {
        currentWaveNumber++;
        canspawn = true;
    }

    void Pause() // function untuk  pause  game dan membuka powerup selection
    {
        isPaused = true;
        PowerSelectionMenu.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void Resume() // function untuk menjalankan game lagi setelah memilih power up
    {
        if (isPaused == false)
        {
            PowerSelectionMenu.SetActive(false);
            Time.timeScale = 1f;
            WaveCounter = 1;
            spawnNextWave();
        }
    }

    public void gameComplete()
    {
        timer.completeTime();
        completeGameMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
