using System;
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
            //Debug.Log("Transition to dead state");
            animationController.SetAnimationDead();
            actuator.StopMoving();
        }
    }
}