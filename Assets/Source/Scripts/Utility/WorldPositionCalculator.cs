using UnityEngine;

public class WorldPositionCalculator
{
    private readonly PlayerInput _playerInput;
    private readonly Camera _camera;

    public WorldPositionCalculator(PlayerInput playerInput)
    {
        _playerInput = playerInput;

        _camera = Camera.main;
    }

    public Vector3 GetTapWorldPosition()
    {
        Vector2 screenPosition = _playerInput.Player.TabPosition.ReadValue<Vector2>();

        return _camera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, _camera.nearClipPlane));
    }
}
