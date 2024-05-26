using UnityEngine;

public class SphereZone : Zone
{
    [SerializeField] private float _size;

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawSphere(transform.position, _size);
    }

    protected override Collider[] GetColliders()
    {
        return Physics.OverlapSphere(transform.position, _size);
    }
}
