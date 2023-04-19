using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectorController : MonoBehaviour
{
    [SerializeField] private Transform originTransform;
    [SerializeField] private Transform focalPoint;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

    private RaycastHit _hit;

    private float _progress;

    private bool _isFound;
    private bool _wasUsed;

    private InteractiveObject _item;

    public void SetFocusPoint(Transform point)
    {
        focalPoint = point;
    } 
    private void Update()
    {
        if (CheckVisual())
        {
            _item ??= _hit.collider.GetComponent<InteractiveObject>();
            if (!_isFound)
                Taptic.Heavy();
            _isFound = true;
            if (_item.IsActive && !_wasUsed)
            {
                UpdateProgress(1);
                if (_progress >= 1)
                {
                    _item.Interact();
                    //ResetProgress();
                    _wasUsed = true;
                }
            }
        }
        else if (_isFound)
        {
            ResetProgress();
            _isFound = false;
            _item = null;
            _wasUsed = false;
        }
        BroadcastProgressEvent();
        
    }

    private bool CheckVisual()
    {
        if (Physics.Raycast(originTransform.position, focalPoint.position - originTransform.position, out _hit,
            maxDistance, layerMask))
        {
            Debug.DrawRay(originTransform.position, (focalPoint.position - originTransform.position).normalized * _hit.distance,
                Color.green);
            return true;
        }
        else
        {
            Debug.DrawRay(originTransform.position, (focalPoint.position - originTransform.position).normalized * maxDistance,
                Color.red);
            return false;
        }
    }

    private void UpdateProgress(float rate)
    {
        _progress += rate * Time.deltaTime;
        //BroadcastProgressEvent();
    }

    private void ResetProgress()
    {
        _progress = 0;
        //BroadcastProgressEvent();
    }
    private void BroadcastProgressEvent()
    {
        var evt = GameEventsHandler.ItemInteractProgressUpdateEvent;
        evt.Progress = _progress;
        evt.ScannerWorldPosition = focalPoint.position;
        EventManager.Broadcast(evt);
    }
}