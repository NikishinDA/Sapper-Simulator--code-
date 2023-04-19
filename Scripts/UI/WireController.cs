using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class WireController : MonoBehaviour
{
    [SerializeField] private Transform originPoint;
    [SerializeField] private Transform puller;
    [SerializeField] private UILineTextureRenderer wireRenderer;
    private Vector2[] _positions = new Vector2[2];

    private void Start()
    {
        _positions[0] = transform.InverseTransformPoint( originPoint.position);
        _positions[1] = transform.InverseTransformPoint( puller.position);
        wireRenderer.Points = _positions;
    }

    private void Update()
    {
        _positions[1] = transform.InverseTransformPoint( puller.position);
        wireRenderer.Points = _positions;
        wireRenderer.SetAllDirty();
    }
}