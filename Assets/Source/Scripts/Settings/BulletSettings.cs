using UnityEngine;

[CreateAssetMenu(fileName = "Bullet settings", menuName = "Game/Bullet/Settings/Create")]
public class BulletSettings : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private float _destroyDelay;

    public float DestroyDelay=>_destroyDelay;
    public float Speed => _speed;
    public float Damage => _damage;
}
