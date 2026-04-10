using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    [SerializeField] public Wave[] waves;

    List<Hole> AvaliableHoles;

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
       
    }
    private void SpawnWave(Wave waveToSpawn)
    {
        for (int i = 0; i < waveToSpawn.EnemiesInWave.Count; i++)
        {
            AvaliableHoles = GameManager.Instance.holeManager.SearchAvaliableHoles();
            int index = Random.Range(0, AvaliableHoles.Count);
            Vector2 position = AvaliableHoles[index].transform.position;
            Instantiate(waveToSpawn.EnemiesInWave[i], position, Quaternion.identity);
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
