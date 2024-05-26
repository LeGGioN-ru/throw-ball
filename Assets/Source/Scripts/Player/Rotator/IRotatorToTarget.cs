using UnityEngine;

public interface IRotatorToTarget 
{
    public Quaternion GetRotation(Transform target);
}
