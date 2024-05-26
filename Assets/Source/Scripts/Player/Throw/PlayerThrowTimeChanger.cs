using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerThrowTimeChanger : IInitializable, IDisposable
{
    private readonly TimeSpeedChanger _timeSpeedChanger;
    private readonly HeldTap _heldTap;
    private readonly PlayerInput _playerInput;
    private readonly ThrowTimeScaleSettings _throwTimeScaleSettings;

    private bool _isHeldTimeChanged = false;

    public PlayerThrowTimeChanger(TimeSpeedChanger timeSpeedChanger, HeldTap heldTap, PlayerInput playerInput,
        ThrowTimeScaleSettings throwTimeScaleSettings)
    {
        _timeSpeedChanger = timeSpeedChanger;
        _heldTap = heldTap;
        _playerInput = playerInput;
        _throwTimeScaleSettings = throwTimeScaleSettings;
    }

    public void Initialize()
    {
        _playerInput.Player.TapUp.performed += OnTapUp;
        _heldTap.Held += OnHeld;
    }

    public void Dispose()
    {
        _heldTap.Held -= OnHeld;
    }

    private void OnHeld()
    {
        if (_isHeldTimeChanged == false)
        {
            _timeSpeedChanger.ChangeTime(_throwTimeScaleSettings.SlowThrowTimeScale, _throwTimeScaleSettings.ChangeSpeedSlowdown);
            _isHeldTimeChanged = true;
        }
    }

    private void OnTapUp(InputAction.CallbackContext context)
    {
        _isHeldTimeChanged = false;

        _timeSpeedChanger.ChangeTime(1f, _throwTimeScaleSettings.ChangeSpeedBoost);
    }
}
