using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemMover : MonoBehaviour
{
    [SerializeField] private Transform itemTransform;
    [SerializeField] private Transform originTransform;
    [SerializeField] private Vector2 moveSpeed;
    private Camera _mainCamera;

    private Vector3 _mousePos;
    private Vector3 _itemPos;
    private float _zOffset;
    private bool _isActive;

    [SerializeField] private PlayerInputManager inputManager;

    private Vector3 _leftDownBorder;
    private Vector3 _rightUpBorder;
    private Vector3 _move;
    private void Awake()
    {
        _mainCamera = Camera.main;
        _zOffset = itemTransform.localPosition.z;
        EventManager.AddListener<BombFoundEvent>(OnBombFound);
        EventManager.AddListener<BombDefuseEvent>(OnBombDefuse);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<BombFoundEvent>(OnBombFound);
        EventManager.RemoveListener<BombDefuseEvent>(OnBombDefuse);

    }

    private void Start()
    {
        var parent = itemTransform.parent;
        _leftDownBorder = parent.InverseTransformPoint(_mainCamera.ViewportToWorldPoint(Vector3.forward * _zOffset + Vector3.up * 0.1f + Vector3.right * 0.1f));
        _rightUpBorder = parent.InverseTransformPoint(_mainCamera.ViewportToWorldPoint(Vector3.right * 0.9f + Vector3.up * 0.9f + Vector3.forward * _zOffset));
    }

    private void OnBombFound(BombFoundEvent obj)
    {
        _isActive = false;
    }

    private void OnBombDefuse(BombDefuseEvent obj)
    {
        //_isActive = true;
    }

    public void SetActive(bool toggle)
    {
        _isActive = toggle;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && _isActive)
        {
            _mousePos = Input.mousePosition;
            _mousePos.z = _zOffset;
            _itemPos = itemTransform.parent.InverseTransformPoint(_mainCamera.ScreenToWorldPoint(_mousePos));
            _move = itemTransform.localPosition + (Vector3) (inputManager.TouchDelta  * moveSpeed);
            _move.x = Mathf.Clamp(_move.x, _leftDownBorder.x, _rightUpBorder.x);
            _move.y = Mathf.Clamp(_move.y, _leftDownBorder.y, _rightUpBorder.y);
            itemTransform.localPosition = _move;//(Vector3) joystick.Direction * (Time.deltaTime * moveSpeed);//Vector3.MoveTowards(itemTransform.localPosition, _itemPos, moveSpeed * Time.deltaTime);
            itemTransform.forward = itemTransform.position - originTransform.position;
        }
    }
}
