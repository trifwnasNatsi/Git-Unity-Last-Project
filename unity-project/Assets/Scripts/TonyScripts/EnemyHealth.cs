using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health;
    //private Hitbox.collisionType type;

    public void TakeDamage(float damage) 
    { 

        // Apply damage with the appropriate multiplier
        health -= damage;
    }

    public float GetHealth()
    {
        return health;
        
    }

}
