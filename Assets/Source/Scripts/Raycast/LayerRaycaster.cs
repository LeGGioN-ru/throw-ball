using UnityEngine;

public class LayerRaycaster 
{
    private LayerMask _targetLayerMask;

    public LayerRaycaster(LayerMask targetLayerMask)
    {
        _targetLayerMask = targetLayerMask;
    }

    public bool IsTargetLayerBetween(Vector3 startPoint, Vector3 endPoint)
    {
        Vector3 direction = endPoint - startPoint;
        float distance = direction.magnitude;
        Ray ray = new Ray(startPoint, direction);

        if (Physics.Raycast(ray, out RaycastHit hit, distance, _targetLayerMask))
        {
            return true;
        }

        return false; 
    }

    public bool IsTargetLayerBetween(Transform startObject, Transform endObject)
    {
        return IsTargetLayerBetween(startObject.position, endObject.position);
    }
}
