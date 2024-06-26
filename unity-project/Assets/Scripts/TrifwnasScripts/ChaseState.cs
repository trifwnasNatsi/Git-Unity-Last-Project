using UnityEngine;

public class ChaseState : State
{
    [SerializeField] float doNotTransitionIfUnder = 2;

    public override bool ShouldTransitionIntoState(Observer observer, Transform target)
    {
        if (target != null)
        {

            if (!base.ShouldTransitionIntoState(observer, target))
                return false;

            // Base is OK, do extra checks!
            if (Vector3.Distance(transform.position, target.position) < doNotTransitionIfUnder)
                return false;
            //Debug.Log("ChaseState");
            
        }
        return true;
    }

    public override void _Update(Actuator actuator, Transform target)
    {
        actuator.LookAt_Frame(target, Time.deltaTime);
        actuator.MoveTowards_Frame(target, Time.deltaTime);
    }
}
