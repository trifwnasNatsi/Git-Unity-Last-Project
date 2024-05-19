using System;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private float cooldown = 2;
    float lastTimeUsed = float.NegativeInfinity;
    [SerializeField] private AnimationController animationController;
    public override bool ShouldTransitionIntoState(Observer observer, Transform target)
    {
        if (!base.ShouldTransitionIntoState(observer, target))
        return false;

        // Base is OK, do extra checks!
        if (!isCooldownReady)
        return false;

        animationController.SetAnimationIdle();
        return true;
    }

    bool isCooldownReady => Time.time - lastTimeUsed >= cooldown;

    public override void _Update(Actuator actuator, Transform target)
    {
        // Can i Use it?
        if (isCooldownReady)
        {
            // Yes!
            actuator.Attack(target);
            //Debug.Log("i attacked");
            lastTimeUsed = Time.time;
            actuator.StopMoving();

            // Set the flag to true indicating the attack has occurred
        }
        else
        {
            // Stop moving even if the attack doesn't happen
            actuator.StopMoving();
        }
    }
}