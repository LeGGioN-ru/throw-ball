using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TurretShooter : ITickable
{
    private readonly TurretWatcher _turretWatcher;
    private readonly Transform _turret;
    private readonly Transform _shootPoint;
    private readonly Bullet _bullet;
    private readonly DiContainer _container;
    private readonly Timer _timer;

    public TurretShooter(float shootDelay, TurretWatcher turretWatcher, Transform turret, Transform shootPoint, Bullet bullet, DiContainer container)
    {
        _turret = turret;
        _turretWatcher = turretWatcher;
        _shootPoint = shootPoint;
        _bullet = bullet;
        _container = container;
        _timer = new Timer(shootDelay);
    }

    public void Tick()
    {
        if (_turretWatcher.Target != null)
        {
            _timer.TickTime();

            if (_timer.IsTimeAchieve())
            {
                Bullet bullet = _container.InstantiatePrefabForComponent<Bullet>(_bullet, _shootPoint.position, _turret.rotation, null);
                bullet.transform.SetParent(null);
                _timer.Reset();
            }
        }
        else
        {
            _timer.Reset();
        }
    }
}
