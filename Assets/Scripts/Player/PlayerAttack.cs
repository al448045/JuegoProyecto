using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float damage = 10.0f;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        BaseEnemy enemy = collision.GetComponent<BaseEnemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
