using UnityEngine;

public class XAxisWatcher : IRotatorToTarget
{
    private readonly float _rotationSpeed;
    private readonly Transform _watcher;

    public XAxisWatcher(float rotationSpeed, Transform watcher)
    {
        _rotationSpeed = rotationSpeed;
        _watcher = watcher;
    }

    public Quaternion GetRotation(Transform target)
    {
        Vector3 direction = target.position - _watcher.position;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        Vector3 targetEulerAngles = targetRotation.eulerAngles;

        if (targetRotation.y >= 0)
        {
            targetEulerAngles = new Vector3(targetEulerAngles.x, 0, 0);
        }
        else
        {
            targetEulerAngles = new Vector3(-targetEulerAngles.x + 180, 0, 0);
        }

        Quaternion smoothedRotation = Quaternion.RotateTowards(
            _watcher.localRotation,
            Quaternion.Euler(targetEulerAngles),
            _rotationSpeed * Time.deltaTime
        );

        return smoothedRotation;
    }
}
