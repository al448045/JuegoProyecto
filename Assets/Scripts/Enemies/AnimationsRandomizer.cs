using UnityEngine;

public class AnimationsRandomizer : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        var state = animator.GetCurrentAnimatorStateInfo(0);
        animator.Play(state.fullPathHash, 0 , Random.Range(0.0f, 1.0f));
    }
}
