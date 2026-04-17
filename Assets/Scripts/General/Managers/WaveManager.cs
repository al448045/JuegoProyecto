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
        AvaliableHoles = GameManager.Instance.holeManager.SearchAvaliableHoles();

        for (int i = 0; i < wave.EnemiesInWave.Count; i++)
        {
            // We get a random hole

            int indexer = Random.Range(0, AvaliableHoles.Count - 1);
            Hole currentHole = AvaliableHoles[indexer];

            // We get a reference to the enemy component of the Game Object

            BaseEnemy currentEnemy = wave.EnemiesInWave[i].GetComponent<BaseEnemy>();

            // We calculate the spawning position from the currentHole and the enemy position, then we instantiate it

            Vector3 spawningPosition = new Vector3(currentHole.holeSpriteRenderer.bounds.center.x, currentHole.transform.position.y - currentEnemy.spriteRenderer.bounds.size.y, currentHole.transform.position.z);
            Instantiate(wave.EnemiesInWave[i], spawningPosition, Quaternion.identity);

            // We set the references and the state of the hole

            currentEnemy.currentHole = currentHole;
            GameManager.Instance.holeManager.Change1HoleState(currentHole, true);

            // We remove the hole from the acalivable ones

            AvaliableHoles.RemoveAt(indexer);
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
