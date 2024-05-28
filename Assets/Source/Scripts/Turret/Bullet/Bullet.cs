using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    private readonly Vector3 _targetMove = Vector3.forward;
    protected BulletSettings BulletSettings;

    [Inject]
    public void Construct(BulletSettings bulletSettings)
    {
        BulletSettings = bulletSettings;
    }

    private void Update()
    {
        transform.Translate(BulletSettings.Speed * Time.deltaTime * _targetMove);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage();
        }

        OnCollision();
    }

    protected async virtual void OnCollision()
    {
        await UniTask.WaitForSeconds(BulletSettings.DestroyDelay);
        transform.DetachChildren();
        Destroy(gameObject);
    }
}
