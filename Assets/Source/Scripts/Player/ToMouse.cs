using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMouse : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform _player;
    [SerializeField] private Rigidbody _playerBody;

    private Vector3 _startPos;
    private Vector3 _currentPos;
    private Vector3 _lastDir;

    private void Start()
    {
        _lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        Vector3 dir = Vector3.zero;

        if (Input.GetMouseButtonDown(0))
        {
            _startPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        }

        if (Input.GetMouseButton(0))
        {
            _lineRenderer.enabled = true;
            _currentPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            _currentPos.ZToZero();
            _startPos.ZToZero();
            _lineRenderer.SetPosition(0, Vector3.zero);
            dir = (_currentPos - _startPos) * 20;

            float maxLength = 2f;
            if (dir.magnitude > maxLength)
            {
                dir = dir.normalized * maxLength;
            }

            _lastDir = dir;
            _lineRenderer.SetPosition(1, dir);
            //Debug.Log($"Сила натяжения: {Vector3.Distance(_startPos, _currentPos)}");
        }

        if (Input.GetMouseButtonUp(0))
        {
            _playerBody.velocity = Vector3.zero;
            Debug.Log(_lastDir.normalized);
            _playerBody.AddForce(_lastDir.normalized * 10, ForceMode.Impulse);
            _lineRenderer.enabled = false;
        }
    }
}
