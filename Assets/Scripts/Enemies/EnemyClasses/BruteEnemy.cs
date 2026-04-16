using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class BruteEnemy : BaseEnemy
{
    private void Start()
    {
        actionState = new EnemyMeleeState();
        enemyHealth = 100.0f;
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
