using UnityEngine;
public class Observer : MonoBehaviour
{
    [SerializeField] private bool ignoreOurSkin = true;
    [SerializeField] private bool ignoreTargetSkin = true;

    public float GetDistanceTo(Transform target)
    {
        
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (ignoreOurSkin)
                distance -= transform.lossyScale.z;
            if (ignoreTargetSkin)
                distance -= target.lossyScale.z / 5;
            return distance;
        } else return 0f;
        
        
    }
}