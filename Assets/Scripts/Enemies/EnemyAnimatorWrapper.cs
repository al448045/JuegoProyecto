using UnityEngine;

public class EnemyAnimatorWrapper : MonoBehaviour
{
    public BaseEnemy currentEnemy;

    public void ActionAnimationComplete()
    {
        currentEnemy.ChangeActionState(true);
    }

    public void MakeAction()
    {
        currentEnemy.Action();
    }
}
