using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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
        EnemyWaveController.counter = 0;
        GameManager.Instance.holeManager.ResetHoles();
        Vector3 spawningPosition = new Vector3(50, 50, 0);

        for (int i = 0; i < wave.EnemiesInWave.Count; i++)
        {
            Instantiate(wave.EnemiesInWave[i], spawningPosition, Quaternion.identity);
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
