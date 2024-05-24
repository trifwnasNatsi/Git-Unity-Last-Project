using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] Transform leftLeg;
    [SerializeField] Transform rightLeg;
    private bool gotRightLeg;
    private bool gotLeftLeg;
    private NavMeshAgent navMeshAgent;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component not found.");
        }
    }
    private void Update()
    {
        if (gotLeftLeg)
        {
            leftLeg.transform.localScale = Vector3.zero;
            navMeshAgent.speed = 1;
        }
        if (gotRightLeg)
        {
            rightLeg.transform.localScale = Vector3.zero;
            navMeshAgent.speed = 1;
        }
    }
    public void TakeDamage(float damage) 
    { 

        // Apply damage with the appropriate multiplier
        health -= damage;
    }

    public float GetHealth()
    {
        return health;
        
    }

    public void LeftLegDamage(bool istrue)
    {
        gotLeftLeg = istrue;
    }
    public void RightLegDamage(bool istrue)
    {
        gotRightLeg = istrue;
    }
    public bool GetRightLeg()
    {
        return gotRightLeg;

    }
    public bool GetLeftLeg()
    {
        return gotLeftLeg;

    }


}
