using UnityEngine;

public class EnemyAnimatorWrapper : MonoBehaviour
{
    public BaseEnemy currentEnemy;
    public void ChangeActionState(int boolValue)
    {

    }

    public void ActionAnimationComplete()
    {
        Debug.Log("CACA");
        currentEnemy.ChangeActionState(true);
    }
}
