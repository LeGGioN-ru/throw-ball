using UnityEngine;
using Zenject;

public class TurretWatcher : ITickable
{
    private readonly IRotatorToTarget _rotator;
    private readonly Zone _zoneWatch;
    private readonly Transform _turret;
    private readonly LayerRaycaster _obstaclesChecker;

    private IDamageable _target;

    public IDamageable Target => _target;

    public TurretWatcher(IRotatorToTarget rotator, Zone zone, Transform turret, LayerRaycaster layerRaycaster)
    {
        _zoneWatch = zone;
        _rotator = rotator;
        _turret = turret;
        _obstaclesChecker = layerRaycaster;
    }

    public void Tick()
    {
        if (_zoneWatch.TryFindObject(ref _target) && _target is MonoBehaviour mono)
        {
            if (_obstaclesChecker.IsTargetLayerBetween(_turret, mono.transform) == false)
            {
                _turret.localRotation = _rotator.GetRotation(mono.transform);
            }
        }
        else
        {
            _target = null;
        }
    }
}
