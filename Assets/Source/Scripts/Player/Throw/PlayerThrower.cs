using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerThrower : IInitializable, IDisposable
{
    private readonly Thrower _thrower;
    private readonly Rigidbody _player;
    private readonly PlayerInput _playerInput;
    private readonly IDirector _director;
    private readonly float _maxThrowMagnitude;
    private readonly Vector2 _minMaxForce;

    public PlayerThrower(Thrower thrower, Rigidbody player, IDirector director,
         float maxThrowMagnitude,
         Vector2 minMaxForce, PlayerInput playerInput)
    {
        _maxThrowMagnitude = maxThrowMagnitude;
        _minMaxForce = minMaxForce;
        _thrower = thrower;
        _player = player;
        _director = director;
        _playerInput = playerInput;
    }

    public void Initialize()
    {
        _playerInput.Player.TapUp.performed += OnTapUp;
    }

    public void Dispose()
    {
        _playerInput.Player.TapUp.performed -= OnTapUp;
    }

    private void OnTapUp(InputAction.CallbackContext context)
    {
        Throw();
    }

    public void Throw()
    {
        Vector3 direction = _director.CalculateDirection();

        float relativeMagnitude = direction.magnitude.FindNormalize(0, _maxThrowMagnitude);

        float forceThrow = Mathf.Lerp(_minMaxForce.x, _minMaxForce.y, relativeMagnitude);

        _thrower.Execute(direction, _player, forceThrow, ForceMode.Impulse, true);
    }
}
