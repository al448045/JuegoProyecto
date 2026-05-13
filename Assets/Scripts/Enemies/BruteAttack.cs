using UnityEngine;

public class BruteAttack : MonoBehaviour
{
    public float damage;
    private BaseEnemy baseEnemy;
    [SerializeField]private float attackOffset;

    private void Awake()
    {
        baseEnemy = GetComponentInParent<BaseEnemy>();
    }

    private void Start()
    {
        transform.localPosition = baseEnemy.transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 bruteAttackVector3 = Vector3.left * baseEnemy.facingDirection.x + Vector3.down * baseEnemy.facingDirection.y;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, bruteAttackVector3);
        transform.localPosition = baseEnemy.facingDirection.normalized * attackOffset;
    }
}
