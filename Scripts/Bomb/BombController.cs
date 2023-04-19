using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] private ModuleController[] modules;
    [SerializeField] private ItemRotationController movementController;
    [SerializeField] private BombLevelObjectController levelObjectController;
    private int _completedNumber;
    private void Awake()
    {
        foreach (var moduleController in modules)
        {
            moduleController.ModuleComplete += ModuleComplete;
        }
        EventManager.AddListener<BombActivateEvent>(OnBombActivate);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<BombActivateEvent>(OnBombActivate);

    }

    private void OnBombActivate(BombActivateEvent obj)
    {
        movementController.SetActive(true);
    }


    private void ModuleComplete()
    {
        _completedNumber++;
        if (_completedNumber >= modules.Length)
        {
            var evt = GameEventsHandler.GameOverEvent;
            evt.IsWin = true;
            EventManager.Broadcast(evt);
        }
    }
}
