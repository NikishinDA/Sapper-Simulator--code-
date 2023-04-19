using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class WirePullerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Transform origin;
    [SerializeField] private Transform destination;
    [SerializeField] private float distTolerance = 10f;
    private bool _isDrag;
    private bool _isActive = true;
    public event Action WireSet;
    private void Update()
    {
        if (_isDrag)
        {
            var transform1 = transform;
            transform1.position = Input.mousePosition;
            transform1.right = transform1.position - origin.position;
            if (Vector2.Distance(transform1.position, destination.position) < distTolerance)
            {
                _isActive = false;
                _isDrag = false;
                transform1.position = destination.position;
                WireSet?.Invoke();
            }
            if (Input.GetMouseButtonUp(0))
                _isDrag = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isActive)
        {
            _isDrag = true;
            Taptic.Light();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_isActive)
            _isDrag = false;
    }
}
