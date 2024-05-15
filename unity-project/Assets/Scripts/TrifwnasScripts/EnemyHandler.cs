using UnityEngine;
using UnityEngine.AI;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private StateMachineHandler stateMachine;
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private bool runStateMachine = true;
    [SerializeField] private NavMeshAgent navMeshAgent;
    //[SerializeField] float health, maxHealth = 3f;
    private bool isEnemyActive;
    private float health;
    public bool isActive()
    {
        return isEnemyActive;
    }

    public void Update()
    {
        health = enemyHealth.GetHealth(); // Update the health variable
        if (runStateMachine)
        {
            stateMachine._Update();
            if (health <= 0)
            {
                stateMachine.TransitionToDeadState();
            }
            if (enemyHealth.GetHealth() <= 0)
            {
                // Disable NavMeshAgent to stop movement
                navMeshAgent.enabled = false;

                // Optionally, stop NavMeshAgent's velocity
                navMeshAgent.velocity = Vector3.zero;

                // Stop updating the state machine
                runStateMachine = false;

                // Optionally, trigger death animations
                // animationController.SetAnimationDead();
            }
        }

    }

}