using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : BaseEnemy
{
    private void Start()
    {

        actionState = new EnemyShootState();
        enemyHealth = 75.0f;
        spriteRenderer.color = Color.cyan;
    }

    public override Hole FindNextHole()
    {
        List<Hole> AvaliableHoles = GameManager.Instance.holeManager.SearchAvaliableHoles();
        Vector2 playerPosition = GameManager.Instance.player.transform.position;
        float closestDistance = 0f;
        Hole furthestHole = null;

        foreach (Hole hole in AvaliableHoles)
        {
            float distance = Vector2.Distance(playerPosition, hole.transform.position);
            if (distance > closestDistance)
            {
                closestDistance = distance;
                furthestHole = hole;
            }
        }
        return furthestHole;
    }
}
