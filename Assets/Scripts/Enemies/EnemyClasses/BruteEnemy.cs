using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class BruteEnemy : BaseEnemy
{
    private void Start()
    {

    }

    public override Vector2 FindNextHole()
    {
        List<Hole> AvaliableHoles = gameManager.SearchAvaliableHoles();
        Vector2 playerPosition = gameManager.player.transform.position;
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
        return closestHole.transform.position;
    }
}
