using UnityEngine;

public class CubeZone : Zone
{
    [SerializeField] private Vector3 _size;

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawCube(transform.position, _size);
    }

    protected override Collider[] GetColliders()
    {
        return Physics.OverlapBox(transform.position, _size);
    }
}
