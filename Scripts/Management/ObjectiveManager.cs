using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField] private int objectivesNumber;
    private int _objectivesComplete;
    private void Awake()
    {
        EventManager.AddListener<BombDefuseEvent>(OnBombDefuse);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<BombDefuseEvent>(OnBombDefuse);
    }

    private void OnBombDefuse(BombDefuseEvent obj)
    {
        _objectivesComplete++;
        if (_objectivesComplete >= objectivesNumber)
        {
            EventManager.Broadcast(GameEventsHandler.LevelCompleteEvent);
        }

        var evt1 = GameEventsHandler.LevelHintFoundEvent;
        evt1.NumberCompleted = _objectivesComplete;
        EventManager.Broadcast(evt1);
    }
}
