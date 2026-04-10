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
       if (EnemyWaveController.counter == currentWave.EnemiesInWave.Count)
        {
            if (!finishedWaves)
            {
                IncreaseWave();
                SpawnWave(currentWave);
            }

            else
            {
                Debug.Log("End of waves");
            }
        }
    }
    private void SpawnWave(Wave wave)
    {
        EnemyWaveController.counter = 0;
        for (int i = 0; i < wave.EnemiesInWave.Count; i++)
        {
            AvaliableHoles = GameManager.Instance.holeManager.SearchAvaliableHoles();
            int index = Random.Range(0, AvaliableHoles.Count);
            Vector2 position = AvaliableHoles[index].transform.position;
            Instantiate(wave.EnemiesInWave[i], position, Quaternion.identity);
        }
    }

    private void IncreaseWave()
    {
        if (waveIndex + 1 < waves.Length)
        {
            waveIndex++;
            currentWave = waves[waveIndex];
            Debug.Log("Current Wave: " + currentWave.name);
        }

        else
        {
            finishedWaves = true;
        }
    }
}
