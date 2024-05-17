using CustomInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Settings", menuName = "Player/Settings/Create", order = 1)]
public class PlayerSettings : ScriptableObject
{
    [HorizontalLine("Throw")]

    [SerializeField][AsRange(0, 50)] private Vector2 _minMaxThrowForce;
    [SerializeField] private float _maxRangeThrowLine;
    [SerializeField] private float _throwLineDrawSensitivity;

    public Vector2 MinMaxThrowForce => _minMaxThrowForce;
    public float MaxRangeThrowLine => _maxRangeThrowLine;
    public float ThrowLineDrawSensitivity => _throwLineDrawSensitivity;
}
