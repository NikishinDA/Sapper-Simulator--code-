using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScannerController : MonoBehaviour
{
    [SerializeField] private PlayerItemMover mover;
    [SerializeField] private PlayerDetectorController detectorController;
    [SerializeField] private float moveTime = 0.5f;
    private Vector3 _startPos;
    private Vector3 _endPos;
    private void Awake()
    {
        EventManager.AddListener<BombActivateEvent>(OnBombActivate);
        EventManager.AddListener<GameStartEvent>(OnGameStart);
        _startPos = transform.localPosition;
        _endPos = _startPos.z * Vector3.forward + Vector3.down * 0.15f;
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<BombActivateEvent>(OnBombActivate);
        EventManager.RemoveListener<GameStartEvent>(OnGameStart);
    }

    private void OnGameStart(GameStartEvent obj)
    {
        StartCoroutine(MoveUpCor(moveTime, _startPos, _endPos));
    }

    private void OnBombActivate(BombActivateEvent obj)
    {
        StartCoroutine(MoveDownCor(moveTime, transform.localPosition, _startPos));
    }

    private IEnumerator MoveUpCor(float time, Vector3 start, Vector3 end)
    {
        for (float t = 0; t < time; t += Time.deltaTime)
        {
            transform.localPosition = Vector3.Lerp(start,end, t/time);
            yield return null;
        }
        transform.localPosition = end;
        mover.SetActive(true);
        
        detectorController.enabled = true;
    }
    private IEnumerator MoveDownCor(float time, Vector3 start, Vector3 end)
    {
        mover.SetActive(false);
        detectorController.enabled = false;
        for (float t = 0; t < time; t += Time.deltaTime)
        {
            transform.localPosition = Vector3.Lerp(start,end, t/time);
            yield return null;
        }
        transform.localPosition = end;
        gameObject.SetActive(false);
    }
}
