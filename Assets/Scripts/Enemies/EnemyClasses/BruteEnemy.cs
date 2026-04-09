using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class BruteEnemy : BaseEnemy
{
    private void Start()
    {
        currentHole = FindNextHole();

        idleTime = Random.Range(1f, 2f);
        actionTime = Random.Range(0.5f, 1f);
        changingTime = Random.Range(0.5f, 1.5f);
    }

    public override Hole FindNextHole()
    {
        List<Hole> AvaliableHoles = GameManager.Instance.holeManager.SearchAvaliableHoles();
        Vector2 playerPosition = GameManager.Instance.player.transform.position;
        float closestDistance = float.PositiveInfinity;
        Hole closestHole = null;

        foreach (Hole hole in AvaliableHoles)
        {
            float distance = Vector2.Distance(playerPosition, hole.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestHole = hole;
            }
        }
        return closestHole;
    }
}
