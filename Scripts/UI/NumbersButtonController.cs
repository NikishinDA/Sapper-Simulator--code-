using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumbersButtonController : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text buttonText;
    private int _assignedNumber;
    public event Action<NumbersButtonController,int> ButtonPressed;
    [SerializeField] private Sprite deactiveSprite;
    [SerializeField] private Sprite activeSprite;
    private void Awake()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        ButtonPressed?.Invoke(this, _assignedNumber);
    }

    public void AssignOrder(int number)
    {
        _assignedNumber = number;
        buttonText.text = number.ToString();
    }

    public void SetActive(bool toggle)
    {
        if (toggle)
        {
            button.image.sprite = activeSprite;
        }
        else
        {
            button.image.sprite = deactiveSprite;
        }
    }

    public void DisableInteractions()
    {
        button.interactable = false;
    }
}
