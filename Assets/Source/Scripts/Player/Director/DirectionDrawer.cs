using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class DirectionDrawer : IInitializable, IDisposable
{
    private readonly LineRenderer _directionLine;
    private readonly IDirector _director;
    private readonly PlayerInput _playerInput;
    private readonly HeldTap _heldTap;

    public DirectionDrawer(PlayerInput playerInput, IDirector director, HeldTap heldTap, LineRenderer lineRenderer)
    {
        _directionLine = lineRenderer;
        _playerInput = playerInput;
        _director = director;
        _heldTap = heldTap;
    }

    public void Initialize()
    {
        _directionLine.SetPosition(0, Vector3.zero);

        _heldTap.Held += OnHeld;

        _playerInput.Player.TapUp.performed += OnTapUp;
    }

    public void Dispose()
    {
        _heldTap.Held -= OnHeld;

        _playerInput.Player.TapUp.performed -= OnTapUp;
    }

    private void OnHeld()
    {
        Vector3 direction = _director.CalculateDirection();

        _directionLine.enabled = true;

        _directionLine.SetPosition(1, direction);
    }

    private void OnTapUp(InputAction.CallbackContext context)
    {
        _directionLine.enabled = false;
    }
}
