using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombShakeScreenController : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(WaitCor(1f));
    }

    private IEnumerator WaitCor(float time)
    {
        yield return new WaitForSeconds(time);
        var evt = GameEventsHandler.GameOverEvent;
        evt.IsWin = true;
        EventManager.Broadcast(evt);
    }
}
