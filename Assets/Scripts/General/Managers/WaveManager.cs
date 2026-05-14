using System.Collections;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class WaveManager : MonoBehaviour
{
    [SerializeField] public Wave[] waves;

    List<Hole> AvaliableHoles;
    List<GameObject> CurrentEnemies;

    private int waveIndex = 0;

    public int bruteCounter;
    public int shooterCounter;

    [HideInInspector]
    public bool finishedWaves = false;

    [HideInInspector]
    public Wave currentWave;

    public void StartWaveManager()
    {
        currentWave = waves[waveIndex];
        SpawnWave(currentWave);
        UIHandler.Instance.ChangeWaveText(waveIndex + 1);
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
        //Reset Counters
        ResetEnemyCounters();

        // Set the timer
        GameManager.Instance.timeManager.SetTimer(currentWave.WaveTimeToBeat);

        // Reset Holes and EnemyCounter 

        EnemyWaveController.counter = 0;
        GameManager.Instance.holeManager.ResetHoles();

        //Search AvaliableHoles

        AvaliableHoles = GameManager.Instance.holeManager.SearchAvaliableHoles();

        for (int i = 0; i < wave.EnemiesInWave.Count; i++)
        {
            // Get references to the hole
            Hole actualHole = AvaliableHoles[0];

            // Set spawningPosition
            Vector3 spawningPosition = actualHole.transform.position;
            GameObject myEnemy = Instantiate(wave.EnemiesInWave[i], spawningPosition, Quaternion.identity);

            //Get Enemy Component and initialize it
            BaseEnemy currentEnemy = myEnemy.GetComponentInChildren<BaseEnemy>();
            currentEnemy.InitEnemy();

            //Set Counters
            if (currentEnemy is ShooterEnemy)
            {
                shooterCounter++;
            }

            if (currentEnemy is BruteEnemy)
            {
                bruteCounter++;
            }

            //Change Name
            myEnemy.name = (myEnemy.name + " - " + i);

            // Set references to currentHole and is_hole_occupied
            currentEnemy.currentHole = actualHole;
            GameManager.Instance.holeManager.Change1HoleState(currentEnemy.currentHole, true);

            //Pop Hole from the list
            AvaliableHoles.RemoveAt(0);
        }

        UpdateBruteText(bruteCounter);
        UpdateShooterText(shooterCounter);
    }
    private void IncreaseWave()
    {
        GameManager.Instance.scoreManager.UpdateScoreAtEndOfWave();
        Debug.Log("Wave index: " + waveIndex);
        if (waveIndex + 1  < waves.Length)
        {
            waveIndex++;
            currentWave = waves[waveIndex];
            UIHandler.Instance.ChangeWaveText(waveIndex + 1);
        }

        else
        {
            finishedWaves = true;
        }
    }

    public void UpdateBruteText(int counter)
    {
        UIHandler.Instance.ChangeBruteCounter(counter);
    }

    public void UpdateShooterText(int counter)
    {
        UIHandler.Instance.ChangeShooterCounter(counter);
    }

    private void ResetEnemyCounters()
    {
        bruteCounter = 0;
        shooterCounter = 0;
    }
}
