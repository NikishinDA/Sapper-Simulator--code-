using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchController : MonoBehaviour, IPointerDownHandler
{
    public event Action<bool> Switched;
    private bool _isSwitched;

    public bool IsSwitched => _isSwitched;
    private bool _isActive = true;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_isActive) return;
        _isSwitched = !_isSwitched;
        Switched?.Invoke(_isSwitched);
        transform.Rotate(0, 0, 90);
    }

    public void DisableInteractions()
    {
        _isActive = false;
    }
}