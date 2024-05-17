using UnityEngine;

public class Thrower
{
    public void Execute(Vector3 direction, Rigidbody throwBody, float force, ForceMode forceMode, bool newVelocity = false)
    {
        if (newVelocity && direction != Vector3.zero)
        {
            throwBody.velocity = Vector3.zero;
        }

        throwBody.AddForce(direction.normalized * force, forceMode);
    }
}
