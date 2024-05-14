using UnityEngine;

public static class Vector3Extension
{
    public static Vector3 ZToZero(this Vector3 vector3)
    {
        return new Vector3(vector3.x, vector3.y, 0);
    }
}
