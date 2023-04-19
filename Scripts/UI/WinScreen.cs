using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Button nextButton;
    [SerializeField] private LevelLoaderObject levelLoaderObject;
    private void Awake()
    {
        nextButton.onClick.AddListener(OnNextButtonClick);
        nextButton.interactable = false;
        levelLoaderObject.SceneReady += LevelLoaderObjectOnSceneReady;
    }

    private void LevelLoaderObjectOnSceneReady()
    {
        nextButton.interactable = true;
    }

    private void OnEnable()
    {
        int level = PlayerPrefs.GetInt(PlayerPrefsStrings.Level.Name, PlayerPrefsStrings.Level.DefaultValue);
        levelLoaderObject.StartLoadingScene(level + 1);
    }

    private void OnNextButtonClick()
    {
        SceneLoader.SoftSwitchLevelNext();
        levelLoaderObject.LoadCachedScene();
    }
}
