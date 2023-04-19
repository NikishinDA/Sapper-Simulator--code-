using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] private MinigameController[] minigames;
    private void OnEnable()
    {
        int level = PlayerPrefsStrings.GetIntValue(PlayerPrefsStrings.Level);
        MinigameController minigame = minigames[level % minigames.Length];
        minigame.gameObject.SetActive(true);
        minigame.MinigameWin += MinigameOnMinigameWin;

       
    }

    private void MinigameOnMinigameWin()
    {
        StartCoroutine(WaitCor(1f));
    }

    private IEnumerator WaitCor(float time)
    {
        yield return new WaitForSeconds(time);
        EventManager.Broadcast(GameEventsHandler.BombDefuseEvent);
    }
}
