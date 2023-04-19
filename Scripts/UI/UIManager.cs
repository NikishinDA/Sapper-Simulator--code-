using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject searchScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject minigameScreen;
    [SerializeField] private GameObject bombShakeScreen;
    [SerializeField] private GameObject tutorScreen;

    private void Awake()
    {
        EventManager.AddListener<GameStartEvent>(OnGameStart);
        EventManager.AddListener<GameOverEvent>(OnGameOver);
        EventManager.AddListener<DefuseButtonClickEvent>(OnDefuseButtonClick);
        EventManager.AddListener<LevelCompleteEvent>(OnLevelComplete);
    }


    private void OnDestroy()
    {
        
        EventManager.RemoveListener<GameStartEvent>(OnGameStart);
        EventManager.RemoveListener<GameOverEvent>(OnGameOver);
        EventManager.RemoveListener<DefuseButtonClickEvent>(OnDefuseButtonClick);
        EventManager.RemoveListener<LevelCompleteEvent>(OnLevelComplete);

    }

    private void OnLevelComplete(LevelCompleteEvent obj)
    {
        minigameScreen.SetActive(false);
        bombShakeScreen.SetActive(true);
    }

    private void OnDefuseButtonClick(DefuseButtonClickEvent obj)
    {
        searchScreen.SetActive(false);
        minigameScreen.SetActive(true);
    }

    private void Start()
    {
        startScreen.SetActive(true);
    }

    private void OnGameStart(GameStartEvent obj)
    {
        startScreen.SetActive(false);
        searchScreen.SetActive(true);
        int level = PlayerPrefsStrings.GetIntValue(PlayerPrefsStrings.Level);
        if (level == 1)
        {
            tutorScreen.SetActive(true);
        }
    }
    
    private void OnGameOver(GameOverEvent obj)
    {
        searchScreen.SetActive(false);
        bombShakeScreen.SetActive(false);
        if (obj.IsWin)
        {
            winScreen.SetActive(true);
        }
        else
        {
            loseScreen.SetActive(true);
        }
    }
}
