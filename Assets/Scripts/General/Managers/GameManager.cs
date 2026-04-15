using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
     public WaveManager waveManager;
     public MonoBehaviour player;
    public HoleManager holeManager;

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
    public void ChangePosition(Hole nextHole, Vector2 newPosition)
    {
        float verticalOffset = nextHole.HoleSize.y;
        transform.position = new Vector2(newPosition.x, newPosition.y + verticalOffset);
    }
}
