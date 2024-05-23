using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public enum CollisionType { None, Head, Body, Arms, Legs }
    public CollisionType enemyCollisionType;

}
