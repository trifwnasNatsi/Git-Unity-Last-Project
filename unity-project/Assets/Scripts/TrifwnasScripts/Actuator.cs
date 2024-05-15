using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Actuator : MonoBehaviour
{
    //[SerializeField] private float attackUp = 2;
    //[SerializeField] private float attackExplosionForce = 15;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private bool debugMovement = true;
    //[SerializeField] private bool debugLook = true;
    [SerializeField] private int damagePerAttack;
    private NavMeshAgent navMeshAgent;
    bool hasBeenExecuted = false;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    public void MoveTowards_Frame(Transform destination, float deltaTime)
    {
        if (!hasBeenExecuted)
        {
            Vector3 direction = (destination.position - transform.position).normalized;
            direction.y = 0;
            if (navMeshAgent != null)
            {
                navMeshAgent.SetDestination(destination.position);
            }
            //transform.Translate(direction * moveSpeed * deltaTime);

            if (debugMovement)
                Debug.Log("I am moving to ", destination);

            hasBeenExecuted = true;
        }
    }

    

    public void LookAt_Frame(Transform destination, float deltaTime)
    {
        if (destination != null)
        {
            float rotationSpeed = 1;
            // Calculate the direction to the destination
            Vector3 direction = destination.position - transform.position;

            // Ensure the object only rotates around the y-axis (horizontal plane)
            direction.y = 0f;

            // If the direction is not zero, rotate towards the direction
            if (direction != Vector3.zero)
            {
                // Calculate the rotation to look at the destination
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // Smoothly interpolate towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }

            if (debugMovement)
                Debug.Log("I am looking at " + destination);
        }
            
        
    }


    public void Attack(Transform target)
    {
        
        if (target != null)
        {
            TargetHandler handler = target.GetComponent<TargetHandler>();
            handler.gotHit(damagePerAttack);
            //Debug.Log("I just attacked!", target);
        }

    }

    public void StopMoving()
    {
        moveSpeed = 0;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public void SetMoveSpeed(float movespeed)
    {
        moveSpeed = movespeed;
    }


    /*
     LookAt_Frame functional not needed now

     public void LookAt_Frame(Transform destination, float deltaTime)
    {
        Vector3 pointToLookAt = destination.position;
        pointToLookAt.y = transform.position.y;

        transform.LookAt(pointToLookAt, Vector3.up);

        if (debugMovement)
            Debug.Log("I am looking at", destination);
    }*/





    /* public void Kick(Transform target)
     {
         // Do a basic push back
         Rigidbody rB = target.GetComponent<Rigidbody>();

         if (rB == null)
         {
             Debug.LogError("Assign a RB to target", target);
             return;
         }

         // Past this point we know RB exists
         Vector3 betweenPoint = Vector3.Lerp(transform.position, target.position, 0.5f);
         float distance = Vector3.Distance(transform.position, target.position);
         rB.AddExplosionForce(attackExplosionForce, betweenPoint, distance, attackUp, ForceMode.Impulse);

         Debug.Log("I just attacked!", target);
     }*/
}
