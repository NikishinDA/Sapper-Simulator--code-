using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WireMinigameController : MinigameController
{
    [SerializeField] private Vector2[] leftPositions;
    [SerializeField] private Vector2[] rightPositions;
    [SerializeField] private Transform[] leftConnectors;
    [SerializeField] private Transform[] rightConnectors;

    [SerializeField] private WirePullerController[] wireEnds;

    private int _setWires;
    [SerializeField] private Transform tutor;

    private void OnEnable()
    {
        foreach (var end in wireEnds)
        {
            end.WireSet += EndOnWireSet;
        }
        
        List<Vector2> lPos = new List<Vector2>(leftPositions);
        List<Vector2> rPos = new List<Vector2>(rightPositions);
        foreach (var connector in leftConnectors)
        {
            int rand = Random.Range(0, lPos.Count);
            connector.localPosition = lPos[rand];
            lPos.RemoveAt(rand);
        }

        foreach (var connector in rightConnectors)
        {
            int rand = Random.Range(0, rPos.Count);
            connector.localPosition = rPos[rand];
            rPos.RemoveAt(rand);
        }
        bool tutorShown = PlayerPrefsStrings.GetIntValue(PlayerPrefsStrings.WiresTutorShown) == 1;
        if (!tutorShown)
        {
            tutor.gameObject.SetActive(true);
            PlayerPrefs.SetInt(PlayerPrefsStrings.WiresTutorShown.Name, 1);

        }
    }

    private void EndOnWireSet()
    {
        _setWires++;
        Taptic.Medium();
        if (_setWires >= wireEnds.Length)
        {
            TriggerWinEvent();
            ShowGreenLight();
        }
    }
}
