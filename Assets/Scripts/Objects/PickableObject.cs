using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public int damageDealt;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
