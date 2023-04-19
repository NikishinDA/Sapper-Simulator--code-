using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameController : MonoBehaviour
{
    public event Action MinigameWin;
    [SerializeField] protected Image buzzerImage;
    [SerializeField] protected Image buzzerLight;
    [SerializeField] protected Sprite redBuzzer;
    [SerializeField] protected Sprite greenBuzzer;
    [SerializeField] protected Sprite greenLight;

    private IEnumerator _redCor;
    protected void TriggerWinEvent()
    {
        MinigameWin?.Invoke();
    }

    protected void ShowRedLight()
    {
        if (_redCor != null)
        {
            StopCoroutine(_redCor);
        }

        StartCoroutine(_redCor = RedLightCor(0.5f));
    }

    protected void ShowGreenLight()
    {
        buzzerLight.sprite = greenLight;
        buzzerLight.gameObject.SetActive(true);
    }
    private IEnumerator RedLightCor(float time)
    {
        buzzerImage.sprite = redBuzzer;
        for (float t = 0; t < time; t += Time.deltaTime)
        {
            yield return null;
        }

        buzzerImage.sprite = greenBuzzer;
    }
}
