using UnityEngine;

[CreateAssetMenu(fileName = "Turret settings", menuName = "Game/Turret/Settings/Create")]
public class TurretSettings : ScriptableObject
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _shootDelay;

    public float RotationSpeed => _rotationSpeed;
    public float ShootDelay => _shootDelay;
}
