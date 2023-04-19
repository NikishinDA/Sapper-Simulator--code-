using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerProgressBarController : MonoBehaviour
{
    [SerializeField] private Text progressText;
    [SerializeField] private float time;

    private float _timeLeft;
    private float _progress;

    private void Awake()
    {
        _timeLeft = time;
    }

    private void Update()
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            progressText.text = ((_timeLeft / time) * 100).ToString("N2");
            if (_timeLeft <= 0)
            {
                var evt = GameEventsHandler.GameOverEvent;
                evt.IsWin = false;
                EventManager.Broadcast(evt);
            }
        }
    }
}
