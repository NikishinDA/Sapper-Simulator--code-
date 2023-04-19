using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractProgressBarController : MonoBehaviour
{
    [SerializeField] private Image pbImage;
    [SerializeField] private Transform pbTransform;
    [SerializeField] private Transform crosshairTransform;
    private Camera _mainCamera;
    private Vector3 _scannerPos;
    private void Awake()
    {
        _mainCamera = Camera.main;
        EventManager.AddListener<ItemInteractProgressUpdateEvent>(OnInteractProgressUpdate);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<ItemInteractProgressUpdateEvent>(OnInteractProgressUpdate);
    }

    private void OnInteractProgressUpdate(ItemInteractProgressUpdateEvent obj)
    {
        pbImage.fillAmount = obj.Progress;
        _scannerPos = _mainCamera.WorldToScreenPoint(obj.ScannerWorldPosition);
        if (obj.Progress >= 0f)
        {
            pbTransform.position = _scannerPos;
        }

        crosshairTransform.position = _scannerPos;
    }
}