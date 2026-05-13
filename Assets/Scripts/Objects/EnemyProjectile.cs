using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    public float bulletVelocity;
    public float bulletDamage;
    public int spriteSpeedMultiplier;
    private Vector2 direction;
    public Sprite[] projectileSprites;
    private int spriteIndex = 0;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");

        direction = (player.transform.position - transform.position);
        rb2d.linearVelocity = new Vector2(direction.x, direction.y).normalized * bulletVelocity;
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }
    void Update()
    {
        spriteRenderer.sprite = projectileSprites[spriteIndex / spriteSpeedMultiplier];
        spriteIndex++;
        if (spriteIndex >= projectileSprites.Length * spriteSpeedMultiplier)
        {
            spriteIndex = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || (collision.CompareTag("Wall"))) 
        {
            Destroy(gameObject);
        }
    }
}
