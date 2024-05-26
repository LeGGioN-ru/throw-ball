using UnityEngine;
using Zenject;

public class GameRoot : MonoInstaller
{
    [SerializeField] private LineRenderer _directionLine;
    [SerializeField] private Rigidbody _playerBody;
    [SerializeField] private PlayerSettings _playerSettings;
    [SerializeField] private Transform _tr;

    public override void InstallBindings()
    {
        PlayerInput playerInput = new PlayerInput();
        playerInput.Enable();

        Container.BindInstance(playerInput);
        Container.BindInterfacesAndSelfTo<HeldTap>().AsSingle();
        Container.BindInterfacesAndSelfTo<SwipeDirectionCalculator>().AsSingle().WithArguments(_playerSettings.MaxRangeThrowLine, _playerSettings.ThrowLineDrawSensitivity);
        Container.BindInterfacesAndSelfTo<WorldPositionCalculator>().AsSingle();
        Container.BindInterfacesAndSelfTo<DirectionDrawer>().AsSingle().WithArguments(_directionLine);
        Container.BindInterfacesAndSelfTo<Thrower>().AsSingle();
        Container.BindInterfacesAndSelfTo<TimeSpeedChanger>().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerThrowTimeChanger>().AsSingle().WithArguments(_playerSettings.ThrowTimeScaleSettings);
        Container.BindInterfacesAndSelfTo<PlayerThrower>().AsSingle().WithArguments(_playerBody, _playerSettings.MaxRangeThrowLine, _playerSettings.MinMaxThrowForce);

    }
}
