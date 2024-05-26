using CustomInspector;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Settings", menuName = "Player/Settings/Create", order = 1)]
public class PlayerSettings : ScriptableObject
{
    [HorizontalLine("Throw Time Scale")]

    [SerializeField] private ThrowTimeScaleSettings _throwTimeScaleSettings;

    [HorizontalLine("Throw")]

    [SerializeField][AsRange(0, 50)] private Vector2 _minMaxThrowForce;
    [SerializeField] private float _maxRangeThrowLine;
    [SerializeField] private float _throwLineDrawSensitivity;

    #region ReadOnlyPublicValues
    public Vector2 MinMaxThrowForce => _minMaxThrowForce;
    public float MaxRangeThrowLine => _maxRangeThrowLine;
    public float ThrowLineDrawSensitivity => _throwLineDrawSensitivity;
    public ThrowTimeScaleSettings ThrowTimeScaleSettings => _throwTimeScaleSettings;
    #endregion
}

[Serializable]
public class ThrowTimeScaleSettings
{
    [SerializeField] private float _slowThrowTimeScale;
    [SerializeField] private float _changeSpeedBoost;
    [SerializeField] private float _changeSpeedSlowdown;

    public float SlowThrowTimeScale => _slowThrowTimeScale;
    public float ChangeSpeedSlowdown => _changeSpeedSlowdown;
    public float ChangeSpeedBoost => _changeSpeedBoost;
}