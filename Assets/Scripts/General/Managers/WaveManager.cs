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

            //Change Name
            myEnemy.name = (myEnemy.name + " - " + i);

            // Set references to currentHole and is_hole_occupied
            currentEnemy.currentHole = actualHole;
            GameManager.Instance.holeManager.Change1HoleState(currentEnemy.currentHole, true);

            //Pop Hole from the list
            AvaliableHoles.RemoveAt(0);
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
