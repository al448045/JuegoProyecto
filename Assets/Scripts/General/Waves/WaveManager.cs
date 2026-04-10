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

    private void Start()
    {
        SpawnWave(currentWave);
    }
    public void Update()
    {
        Debug.Log("CurrentWave: " + currentWave.name);
        Debug.Log("Number of enemies: " + currentWave.EnemiesInWave.Count);

        CheckForDeadEnemies();

        if (currentWave.EnemiesInWave.Count <= 0)
        {
            //FinishWave();
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
    public void SpawnWave(Wave waveToSpawn)
    {
        for (int i = 0; i < waveToSpawn.EnemiesInWave.Count; i++)
        {
            List<Hole> AvaliableHoles = GameManager.Instance.holeManager.SearchAvaliableHoles();
            int index = Random.Range(0, AvaliableHoles.Count);
            Vector2 position = AvaliableHoles[index].transform.position;
            Instantiate(waveToSpawn.EnemiesInWave[i], position, Quaternion.identity);
        }
    }
    private void FinishWave(Wave waveToFinish)
    {

    }

    private void CheckForDeadEnemies()
    {
        foreach (GameObject enemy in currentWave.EnemiesInWave)
        {
            BaseEnemy baseEnemy = enemy.GetComponentInChildren<BaseEnemy>();

            if (baseEnemy.isEnemyDead)
            {
                enemy.SetActive(false);
            }
        }
    }
}
