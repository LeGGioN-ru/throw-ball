using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class SwipeDirectionCalculator : IDirector, IInitializable, IDisposable
{
    private readonly PlayerInput _playerInput;
    private readonly WorldPositionCalculator _worldPositionCalculator;
    private readonly HeldTap _heldTap;
    private readonly float _maxMagnitude;
    private readonly float _directionSensitivity;

    private bool _isFirstTap = true;
    private Vector3 _startPosition;
    private Vector3 _currentPosition;

    public SwipeDirectionCalculator(WorldPositionCalculator worldPositionCalculator, HeldTap heldTap, PlayerInput playerInput,
        float maxMagnitude, float directionSensitivity)
    {
        _maxMagnitude = maxMagnitude;
        _directionSensitivity = directionSensitivity;
        _playerInput = playerInput;
        _worldPositionCalculator = worldPositionCalculator;
        _heldTap = heldTap;
    }

    public void Initialize()
    {
        _playerInput.Enable();

        _heldTap.Held += OnHeld;
        _playerInput.Player.TapDown.performed += OnStarted;
    }

    public void Dispose()
    {
        _playerInput.Disable();

        _heldTap.Held -= OnHeld;
        _playerInput.Player.TapDown.performed -= OnStarted;
    }

    private void OnHeld()
    {
        _currentPosition = _worldPositionCalculator.GetTapScreenPosition();

        TryFixFirstTap();
    }

    public Vector3 CalculateDirection()
    {
        Vector3 direction = (_currentPosition - _startPosition) * _directionSensitivity;

        if (direction.magnitude > _maxMagnitude)
        {
            direction = direction.normalized * _maxMagnitude;
        }

        return direction;
    }

    private void OnStarted(InputAction.CallbackContext context)
    {
        _startPosition = _worldPositionCalculator.GetTapScreenPosition();
    }

    private void TryFixFirstTap()
    {
        if (_isFirstTap == true)
        {
            _startPosition = _currentPosition;
            _isFirstTap = false;
        }
    }
}
