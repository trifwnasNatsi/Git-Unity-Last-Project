using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;
    [HideInInspector] public WeaponManager weapon;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        // Ensure we are getting the Hitbox component from the exact collider involved in the collision
        Hitbox hitbox = collision.collider.GetComponent<Hitbox>();
        if (hitbox != null)
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponentInParent<EnemyHealth>();
            if (enemyHealth != null)
            {
                switch (hitbox.enemyCollisionType)
                {
                    case Hitbox.CollisionType.Head:
                        enemyHealth.TakeDamage(weapon.damage * 5);
                        //Debug.Log("Headshot! Applied damage: " + (weapon.damage * 5));
                        break;
                    case Hitbox.CollisionType.Body:
                        enemyHealth.TakeDamage(weapon.damage * 3);
                        //Debug.Log("Body hit! Applied damage: " + (weapon.damage * 3));
                        break;
                    case Hitbox.CollisionType.Arms:
                        enemyHealth.TakeDamage(weapon.damage);
                        //Debug.Log("Arm hit! Applied damage: " + weapon.damage);
                        break;
                    case Hitbox.CollisionType.RightLeg:
                        enemyHealth.TakeDamage(weapon.damage);
                        enemyHealth.RightLegDamage(true);
                        //Debug.Log("Leg hit! Applied damage: " + weapon.damage);
                        break;
                    case Hitbox.CollisionType.LeftLeg:
                        enemyHealth.TakeDamage(weapon.damage);
                        enemyHealth.LeftLegDamage(true);
                        //Debug.Log("Leg hit! Applied damage: " + weapon.damage);
                        break;
                    default:
                        //Debug.Log("Unhandled hitbox type");
                        break;
                }
            }
        }
        else
        {
            //Debug.Log("No Hitbox component found on the collider.");
        }
    // Destroy the bullet regardless of the collision outcome
    Destroy(this.gameObject);
    }
}
