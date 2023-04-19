using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [Range(0, 0.5f)] [SerializeField] private float turningZone;
    [Range(0, 180)] [SerializeField] private float maxAngleLeft;
    [Range(0, 180)] [SerializeField] private float maxAngleRight;

    private float _mouseViewportX;

    private Camera _mainCamera;

    [SerializeField] private Transform cameraTransform;

    [SerializeField] private float turnSpeed;

    private Vector3 _rotation;
    private Vector3 _startRotation;
    private bool _isActive;
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private Transform scannerTransform;
    private void Awake()
    {
        _mainCamera = Camera.main;
        _rotation = cameraTransform.localEulerAngles;
        _startRotation = _rotation;
        EventManager.AddListener<BombActivateEvent>(OnBombActivate);
        EventManager.AddListener<GameStartEvent>(OnGameStart);
        EventManager.AddListener<BombFoundEvent>(OnBombFound);
        EventManager.AddListener<BombDefuseEvent>(OnBombDefuse);
        EventManager.AddListener<GameOverEvent>(OnGameOver);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<BombActivateEvent>(OnBombActivate);
        EventManager.RemoveListener<GameStartEvent>(OnGameStart);
        EventManager.RemoveListener<BombFoundEvent>(OnBombFound);
        EventManager.RemoveListener<BombDefuseEvent>(OnBombDefuse);
        EventManager.RemoveListener<GameOverEvent>(OnGameOver);

    }

    private void OnGameOver(GameOverEvent obj)
    {
        explosionEffect.Play();
    }

    private void OnBombFound(BombFoundEvent obj)
    {
        _isActive = false;
    }

    private void OnBombDefuse(BombDefuseEvent obj)
    {
        //_isActive = true;
    }

    private void OnGameStart(GameStartEvent obj)
    {
        _isActive = true;
    }

    private void OnBombActivate(BombActivateEvent obj)
    {
        _isActive = false;
    }

    private void Update()
    {
        /*if (!Input.GetMouseButton(0) || !_isActive) return;
        _mouseViewportX = Mathf.Clamp01(_mainCamera.ScreenToViewportPoint(Input.mousePosition).x);*/
        _mouseViewportX = Mathf.Clamp01(_mainCamera.WorldToViewportPoint(scannerTransform.position).x);
        if (_mouseViewportX < turningZone && _rotation.y >= -maxAngleLeft)
        {
            _rotation.y += -turnSpeed * Time.deltaTime *
                           ((turningZone - _mouseViewportX) / turningZone);
        }
        else if (_mouseViewportX > 1 - turningZone && _rotation.y <= maxAngleRight)
        {
            _rotation.y += turnSpeed * Time.deltaTime * ((_mouseViewportX - 1 + turningZone) / turningZone);
        }
        else
        {
            return;
        }

        cameraTransform.localEulerAngles = _rotation;
    }
}