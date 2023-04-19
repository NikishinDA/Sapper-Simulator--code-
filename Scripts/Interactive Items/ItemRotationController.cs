using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotationController : MonoBehaviour
{
    private Vector2 _oldMousePos;
    private Vector2 _newMousePos;
    private Vector2 _deltaPos;
    [SerializeField] private Vector2 rotationSpeed;

    private bool _isActive;
    private Vector3 _parentUp;
    private Vector3 _parentRight;
    public void SetActive(bool toggle)
    {
        _isActive = toggle;
    }

    public void SetDimension()
    {
        var parent = transform.parent;
        _parentRight = parent.right;
        _parentUp = parent.up;
    }
    private void OnMouseDown()
    {
        if (!_isActive) return;
        _oldMousePos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        if (!_isActive) return;
        _newMousePos = Input.mousePosition;
        _deltaPos = (_newMousePos - _oldMousePos) * rotationSpeed;
        transform.Rotate(_parentUp, -_deltaPos.x, Space.World);
        transform.Rotate(_parentRight, _deltaPos.y, Space.World);
        _oldMousePos = _newMousePos;
    }
}
