using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public enum CollisionType { None, Head, Body, Arms, RightLeg, LeftLeg }
    public CollisionType enemyCollisionType;

}
