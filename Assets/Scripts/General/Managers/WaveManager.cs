using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    [SerializeField] public Wave[] waves;

    List<Hole> AvaliableHoles;
    List<GameObject> CurrentEnemies;

    private int waveIndex = 0;

    [HideInInspector]
    public bool finishedWaves = false;

    [HideInInspector]
    public Wave currentWave;

    private void Awake()
    {
        currentWave = waves[waveIndex];
    }

    private void Start()
    {
        SpawnWave(currentWave);
    }
    public void Update()
    {
       if (EnemyWaveController.counter >= currentWave.EnemiesInWave.Count)
        {
            if (finishedWaves)
            {
                Debug.Log("End of waves");
            }

            else
            {
                IncreaseWave();
                SpawnWave(currentWave);
            }
        }
    }
    private void SpawnWave(Wave wave)
    {
        Debug.Log("Current Wave: " + wave.name);
        EnemyWaveController.counter = 0;
        GameManager.Instance.holeManager.ResetHoles();
        Vector2 position = new Vector2(100,100);

        for (int i = 0; i < wave.EnemiesInWave.Count; i++)
        {
            Instantiate(wave.EnemiesInWave[i], position, Quaternion.identity);
        }
    }

    private void IncreaseWave()
    {
        if (waveIndex + 1 < waves.Length)
        {
            waveIndex++;
            currentWave = waves[waveIndex];
        }

        else
        {
            finishedWaves = true;
        }
    }
}
