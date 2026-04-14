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

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || (collision.CompareTag("Wall"))) 
        { 
            Destroy(gameObject);
        }
    }
}
