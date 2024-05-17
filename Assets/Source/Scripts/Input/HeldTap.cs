using System;
using UnityEngine;
using Zenject;

public class HeldTap : ITickable
{
    private readonly PlayerInput _playerInput;

    public event Action Held;

    public HeldTap(PlayerInput playerInput)
    {
        _playerInput = playerInput;
    }

    public void Tick()
    {
        if (_playerInput.Player.Tap.IsPressed())
        {
            Held?.Invoke();
        }
    }
}
