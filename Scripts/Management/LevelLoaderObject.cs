using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LevelLoaderObject : MonoBehaviour
{
    private AsyncOperation _sceneLoading;
    private bool _sceneReady;
    public event Action SceneReady;
    public void StartLoadingScene(int sceneNum)
    {
        StartCoroutine(LoadScene(sceneNum));
    }

    private IEnumerator LoadScene(int num)
    {
        yield return null;
        if (num >= SceneManager.sceneCountInBuildSettings)
        {
            num = Random.Range(1, SceneManager.sceneCountInBuildSettings);
        }
        if (num == 0)
        {
            num = 1;
            int level = PlayerPrefs.GetInt(PlayerPrefsStrings.Level.Name, PlayerPrefsStrings.Level.DefaultValue);
            PlayerPrefs.SetInt(PlayerPrefsStrings.Level.Name, level +  num);
            PlayerPrefs.Save();
        }
        _sceneLoading = SceneManager.LoadSceneAsync(num);
        _sceneLoading.allowSceneActivation = false;
        while (!_sceneLoading.isDone)
        {

            if (_sceneLoading.progress >= 0.9f)
            {
                _sceneReady = true;
                SceneReady?.Invoke();
                yield break;
            }

            yield return null;
        }
    }

    public void LoadCachedScene()
    {
        if (_sceneLoading == null || !_sceneReady) return;
        _sceneLoading.allowSceneActivation = true;
    }
}
