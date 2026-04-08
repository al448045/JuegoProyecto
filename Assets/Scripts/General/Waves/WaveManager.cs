using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] public Wave[] waves;

    private float timeBetweenSpawns;
    private int waveIndex = 0;

    [HideInInspector]
    public bool finishedWaves = false;
    public Wave currentWave;


    private void Awake()
    {
        currentWave = waves[waveIndex];
    }
    public void SpawnWave()
    {
        for (int i = 0; i < currentWave.EnemiesInWave.Length; i++)
        {
            List<Hole> AvaliableHoles = gameManager.SearchAvaliableHoles();
            int index = Random.Range(0, AvaliableHoles.Count);
            Vector2 position = AvaliableHoles[index].transform.position;
            Instantiate(currentWave.EnemiesInWave[i], position, Quaternion.identity);
        }
    }

    public void Update()
    {
        if (currentWave.EnemiesInWave.Length <= 0)
        {
            FinishWave();
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

    private void FinishWave()
    {

    }
}
