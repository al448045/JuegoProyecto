using UnityEngine;
using System.Collections.Generic;
using System.Security.Cryptography;

public class GameManager : MonoBehaviour
{
    public WaveManager waveManager;
    public MonoBehaviour player;
    public HoleManager holeManager;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            waveManager = GetComponent<WaveManager>();
            holeManager = GetComponent<HoleManager>();
        }
    }
    private void Start()
    {

    }

    public HoleManager GetHoleManager()
    {
        return holeManager;
    }

    public WaveManager GetWaveManager()
    {
        return waveManager;
    }
}