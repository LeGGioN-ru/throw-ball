using UnityEngine;
using Zenject;

public class TurretWatcher : ITickable
{
    private readonly IRotatorToTarget _rotator;
    private readonly Zone _zoneWatch;
    private readonly Transform _turret;

    private Transform _player;

    public TurretWatcher(IRotatorToTarget rotator, Transform turret)
    {
        _rotator = rotator;
        _turret = turret;
    }

    public void Tick()
    {
        if (_player == null)
        {

        }

        if(_player != null )
        {
            _turret.localRotation = _rotator.GetRotation(_player);
        }
    }
}
