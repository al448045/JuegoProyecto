using UnityEngine;

public class EnemyAnimatorWrapper : MonoBehaviour
{
    public BaseEnemy currentEnemy;
    public void ChangeActionState(int boolValue)
    {

    }

    public void ActionAnimationComplete()
    {
        currentEnemy.ChangeActionState(true);
    }
}
