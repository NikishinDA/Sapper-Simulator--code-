using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NumbersMinigameController : MinigameController
{
    [SerializeField] private NumbersButtonController[] buttons;
    private int _currentCount = 1;
    private List<NumbersButtonController> _buttonList;
    [SerializeField] private Transform tutor;
    private void OnEnable()
    {
        List<NumbersButtonController> preList = new List<NumbersButtonController>(buttons);
        _buttonList = new List<NumbersButtonController>();
        while (preList.Count > 0)
        {
            int rand = Random.Range(0, preList.Count);
            _buttonList.Add(preList[rand]);
            preList.RemoveAt(rand);
        }

        for (var i = 0; i < _buttonList.Count; i++)
        {
            _buttonList[i].AssignOrder(i+1);
            _buttonList[i].ButtonPressed += OnButtonPressed;
        }
        bool tutorShown = PlayerPrefsStrings.GetIntValue(PlayerPrefsStrings.NumbersTutorShown) == 1;
        if (!tutorShown)
        {
            tutor.gameObject.SetActive(true);
            tutor.position = _buttonList[0].transform.position;
            PlayerPrefs.SetInt(PlayerPrefsStrings.NumbersTutorShown.Name, 1);

        }
    }

    private void OnButtonPressed(NumbersButtonController buttonController, int number)
    {
        if (number == _currentCount)
        {
            _currentCount++;
            buttonController.SetActive(true);
            if (_currentCount > buttons.Length)
            {
                TriggerWinEvent();
                foreach (var button in buttons)
                {
                    button.DisableInteractions();
                }
                ShowGreenLight();
            }
            Taptic.Medium();
        }
        else
        {
            foreach (var button in _buttonList)
            {
                button.SetActive(false);
            }
            ShowRedLight();
            Taptic.Failure();
            _currentCount = 1;
        }
    }

}
