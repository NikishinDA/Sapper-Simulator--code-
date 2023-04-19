using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchMinigameController : MinigameController
{
    [SerializeField] private SwitchController firstSwitch;
    [SerializeField] private SwitchController secondSwitch;

    private IEnumerator _firstFill;
    private IEnumerator _secondFill;

    [SerializeField]
    private float fillTime;

    [SerializeField] private Image firstCircuitFill;
    [SerializeField] private Image secondCircuitFill;
    [SerializeField] private Transform tutor;

    private void OnEnable()
    {
        firstSwitch.Switched += FirstSwitchOnSwitched;
        secondSwitch.Switched += SecondSwitchOnSwitched;
        _firstFill = FillCor(fillTime, firstCircuitFill);
        _secondFill = FillCor(fillTime, secondCircuitFill);
        bool tutorShown = PlayerPrefsStrings.GetIntValue(PlayerPrefsStrings.SwitchTutorShown) == 1;
        if (!tutorShown)
        {
            tutor.gameObject.SetActive(true);
            PlayerPrefs.SetInt(PlayerPrefsStrings.SwitchTutorShown.Name, 1);
        }
    }

    private void FirstSwitchOnSwitched(bool obj)
    {
        if (obj)
        {
            StartCoroutine(_firstFill = FillCor(fillTime, firstCircuitFill));
            if (secondSwitch.IsSwitched)
            {
                StartCoroutine(_secondFill = FillCor(fillTime, secondCircuitFill));
                Win();
            }
            Taptic.Medium();
        }
        else
        {
            StopCoroutine(_firstFill);
            StopCoroutine(_secondFill);
            firstCircuitFill.fillAmount = 0;
            secondCircuitFill.fillAmount = 0;
        }
    }

    private void SecondSwitchOnSwitched(bool obj)
    {
        if (obj)
        {
            if (firstSwitch.IsSwitched)
            {
                StartCoroutine(_secondFill= FillCor(fillTime, secondCircuitFill));
                Win();
            }
            Taptic.Medium();

        }
        else
        {
            StopCoroutine(_secondFill);
            secondCircuitFill.fillAmount = 0;
        }
    }

    private IEnumerator FillCor(float time, Image fill)
    {
        for (float t = 0; t < time; t += Time.deltaTime)
        {
            fill.fillAmount = Mathf.Lerp(0f, 1f, t / time);
            yield return null;
        }
    }

    private void Win()
    {
        TriggerWinEvent();
        firstSwitch.DisableInteractions();
        secondSwitch.DisableInteractions();
        ShowGreenLight();
    }
    
}
