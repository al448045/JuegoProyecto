using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public WaveManager waveManager;
    public MonoBehaviour player;
    public HoleManager holeManager;
    public ScoreManager scoreManager;
    public TimeManager timeManager;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            waveManager = GetComponentInChildren<WaveManager>();
            holeManager = GetComponentInChildren<HoleManager>();
        }
    }
    public void Start()
    {

    }
}
