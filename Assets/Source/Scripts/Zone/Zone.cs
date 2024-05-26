using System.Collections.Generic;
using UnityEngine;

public abstract class Zone : MonoBehaviour
{
    [SerializeField] protected Color Color;

    protected abstract Collider[] GetColliders();

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color;
    }

    private List<T> FindObjects<T>()
    {
        List<T> foundObjects = new List<T>();
        Collider[] colliders = GetColliders();

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out T component))
            {
                foundObjects.Add(component);
            }
        }

        return foundObjects;
    }

    public bool TryFindObject<T>(ref T obj)
    {
        List<T> objects = FindObjects<T>();

        if (objects.Count > 0)
        {
            obj = objects[0];
            return true;
        }

        return false;
    }

    public bool TryFindObjects<T>(out List<T> objects)
    {
        objects = FindObjects<T>();
        return objects.Count > 0;
    }
}
