using CustomInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TurretInstaller : MonoInstaller
{
    [SerializeField] private Transform _turret;
    [SerializeField] private Zone _zone;
    [AssetsOnly][SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private BulletSettings _bulletSettings;
    [SerializeField] private TurretSettings _turretSettings;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private LayerMask _obstacles;

    public override void InstallBindings()
    {
        Container.BindInstance(_zone);
        Container.BindInstance(_bulletSettings);
        LayerRaycaster layerRaycaster = new LayerRaycaster(_obstacles);
        Container.BindInterfacesAndSelfTo<TurretShooter>().AsSingle().WithArguments(_turretSettings.ShootDelay, _turret, _shootPoint, _bulletPrefab);
        Container.BindInterfacesAndSelfTo<XAxisWatcher>().AsSingle().WithArguments(_turretSettings.RotationSpeed, _turret);
        Container.BindInterfacesAndSelfTo<TurretWatcher>().AsSingle().WithArguments(_turret, layerRaycaster);
    }
}
