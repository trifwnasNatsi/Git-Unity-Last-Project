using System;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [Tooltip("Lower number <=> Higher priority (same as AudioSource prio))")]
    public uint priority => _priority;
    [Range(0, 100)]
    [SerializeField] private uint _priority;

    [SerializeField] private float transitionIfUnder;
    internal Transform target;

    public virtual bool ShouldTransitionIntoState(Observer observer, Transform target)
    {
        return observer.GetDistanceTo(target) < transitionIfUnder;
    }

    public abstract void _Update(Actuator actuator, Transform target);
}
