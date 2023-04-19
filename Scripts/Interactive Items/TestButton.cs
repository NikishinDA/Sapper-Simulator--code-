using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : ModuleController
{
    private bool _isPressed;
    private Vector3 _startPos;
    private Vector3 _endPos;
    [SerializeField] private Material pressMaterial;
    [SerializeField] private Material unpressMaterial;
    private Renderer _renderer;
    private void Awake()
    {
        _startPos = transform.localPosition;
        _endPos = _startPos;
        _endPos.z += 0.1f;
        _renderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        _isPressed = !_isPressed;
        if (_isPressed)
        {
            transform.localPosition = _endPos;
            _renderer.material = pressMaterial;
            CompleteModule();
        }
        else
        {
            transform.localPosition = _startPos;
            _renderer.material = unpressMaterial;
        }
    }
    
}
