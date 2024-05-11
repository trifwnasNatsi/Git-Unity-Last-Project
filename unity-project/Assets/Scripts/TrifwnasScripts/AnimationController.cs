using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        SetAnimationIdle();
    }


    public void SetAnimationIdle()
    {
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsChasing", false);
        animator.SetBool("IsAttacking", false);
    }
    public void SetAnimationChase()
    {
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsChasing", true);
        animator.SetBool("IsAttacking", false);
    }
    public void SetAnimationAttack()
    {
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsChasing", false);
        animator.SetBool("IsAttacking", true);
    }
    public void SetAnimationDead()
    {

        animator.SetBool("IsDead", true);
    }
}
