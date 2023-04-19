using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void Awake()
    {
        EventManager.AddListener<GameStartEvent>(OnGameStart);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<GameStartEvent>(OnGameStart);

    }

    private void OnGameStart(GameStartEvent obj)
    {
        animator.SetTrigger("start");
    }
}
