using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScannerModelManager : MonoBehaviour
{
    [SerializeField] private ScannerSkinController[] scanners;
    [SerializeField] private PlayerDetectorController detectorController;

    private void Awake()
    {
        int skinNum = PlayerPrefsStrings.GetIntValue(PlayerPrefsStrings.SkinNumber);
        scanners[skinNum].gameObject.SetActive(true);
        detectorController.SetFocusPoint(scanners[skinNum].FocusPoint);
    }
}
