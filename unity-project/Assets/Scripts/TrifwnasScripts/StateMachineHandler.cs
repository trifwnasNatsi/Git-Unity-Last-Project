using System.Collections;
using System.Linq;
using UnityEngine;

public class StateMachineHandler : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Observer observer;
    [SerializeField] private Actuator actuator;
    [SerializeField] private AnimationController animationController;
    private State[] states;

    private void Awake()
    {
        states = GetComponentsInChildren<State>();

        foreach (var state in states)
        {
            state.target = target;
        }
    }

    // Update is called once per frame
    public void _Update()
    {
        // Sort states by priority
        var sortedStates = states.OrderBy(x => x.priority);

        // Set animation based on the highest priority active state
        foreach (State state in sortedStates)
        {
            if (state.ShouldTransitionIntoState(observer, target))
            {
                state._Update(actuator, target);

                // Set animation based on state type
                if (state.GetType() == typeof(AttackState))
                {
                    animationController.SetAnimationAttack();
                    //hasAttacked = true;
                }
                else if (state.GetType() == typeof(ChaseState))
                {
                    animationController.SetAnimationChase();
                    //hasStartedChase = true;
                }
                else if (state.GetType() == typeof(IdleState))
                {
                    animationController.SetAnimationIdle();
                }

                // Break loop after handling the first active state
                break;
            }
        }
    }
    public void TransitionToDeadState()
    {
        // Activate DeadState
        foreach (var state in states)
        {
            if (state.GetType() == typeof(DeadState))
            {
                state._Update(actuator, target);
                break;
            }
        }

        // Set Dead animation
        animationController.SetAnimationDead();
        StartCoroutine(DestroyAfterDelay());
        
    }
    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
