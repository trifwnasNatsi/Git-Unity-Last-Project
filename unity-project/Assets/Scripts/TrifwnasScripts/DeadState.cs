using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    [SerializeField] private AnimationController animationController;
    [SerializeField] private EnemyHealth enemyHealth;
    

    

    public override void _Update(Actuator actuator, Transform target)
    {
        
        float health = enemyHealth.GetHealth();
        if (health <= 0)
        {
            Debug.Log("transition to dead");
            animationController.SetAnimationDead();
            actuator.StopMoving();
        }
        
    }
}
