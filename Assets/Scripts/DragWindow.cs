using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DragWindow : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _headerBoxCollider;
    private Vector2 _headerSize;
    private Vector2 _headerOffset;
    private Camera _camera;
    private float _cameraSize;
    private float _cameraAspect;
    private bool _isMouseDown = false;
    private Vector3 _initialMousePosition;
    private Vector3 _initialPosition;
    private float _taskbarOffset = 1.0f;

    private void Start()
    {
        _camera = Camera.main;
        _cameraSize = _camera.orthographicSize;
        _cameraAspect = _camera.aspect;
        _headerOffset = _headerBoxCollider.offset;
        _headerSize = _headerBoxCollider.size;
    }

    private void OnMouseDown()
    {
        _isMouseDown = true;
        _initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _initialPosition = transform.position;
        GetComponent<Window>().WindowSelected();
    }

    private void Update()
    {
        if (!_isMouseDown)
        {
            return;
        }

        Vector3 m_targetPosition = _initialPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - _initialMousePosition);
        transform.position = ClampPositionToScreen(m_targetPosition);
    }

    private Vector3 ClampPositionToScreen(Vector3 targetPosition)
    {
        targetPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, -(_cameraSize * _cameraAspect) + (_headerSize.x / 2.0f), (_cameraSize * _cameraAspect) - (_headerSize.x / 2.0f)),
            Mathf.Clamp(targetPosition.y, (_headerSize.y / 2.0f) -_cameraSize - (_headerOffset.y * transform.localScale.y) + _taskbarOffset, _cameraSize - (_headerSize.y / 2.0f) - (_headerOffset.y * transform.localScale.y)),
            0.0f);

        return targetPosition;
    }

    private void OnMouseUp()
    {
        _isMouseDown = false;
    }
}
