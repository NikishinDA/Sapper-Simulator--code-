using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintCounterController : MonoBehaviour
{
    [SerializeField] private Text objectivesText;
    [SerializeField] private int objectivesNumber;
    private void Awake()
    {
        EventManager.AddListener<LevelHintFoundEvent>(OnObjectiveComplete);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<LevelHintFoundEvent>(OnObjectiveComplete);
    }

    private void Start()
    {
        objectivesText.text = "0/" + objectivesNumber;
    }

    private void OnObjectiveComplete(LevelHintFoundEvent obj)
    {
        objectivesText.text = obj.NumberCompleted + "/" + objectivesNumber;
    }
}
