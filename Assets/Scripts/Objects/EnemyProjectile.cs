using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb2d;
    public float bulletVelocity;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector2 direction = (player.transform.position - transform.position);
        rb2d.linearVelocity = new Vector2(direction.x, direction.y).normalized * bulletVelocity;
    }
    void Update()
    {
        
    }
}
