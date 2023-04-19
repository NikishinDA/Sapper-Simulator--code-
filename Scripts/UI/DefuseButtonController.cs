using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefuseButtonController : MonoBehaviour
{
    [SerializeField] private GameObject buttonScreen;
    [SerializeField] private Button defuseButton;

    private BombLevelObjectController _bombObject;
    private void Awake()
    {
        defuseButton.onClick.AddListener(OnDefuseButtonClick);
        EventManager.AddListener<BombFoundEvent>(OnBombFound);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<BombFoundEvent>(OnBombFound);
    }

    private void OnBombFound(BombFoundEvent obj)
    {
        buttonScreen.SetActive(true);
        _bombObject = obj.BombObject;
    }

    private void OnDefuseButtonClick()
    {
        if (_bombObject)
        {
            _bombObject.Defuse();
            EventManager.Broadcast(GameEventsHandler.DefuseButtonClickEvent);
        }
        else
        {
            Debug.LogError("Bomb was not selected");
        }
        buttonScreen.SetActive(false);
    }
}
