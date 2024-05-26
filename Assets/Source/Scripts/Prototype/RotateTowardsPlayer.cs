using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    [SerializeField] private Transform player; 
    [SerializeField] private Transform _watcher;
    public float rotationSpeed = 5f; 

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - _watcher.position;

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
                rotationSpeed * Time.deltaTime
            );

            _watcher.localRotation = smoothedRotation;
        }
    }
}
