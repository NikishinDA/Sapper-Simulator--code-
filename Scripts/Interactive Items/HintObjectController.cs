using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintObjectController : InteractiveObject
{
    private Collider _collider;
    private void Awake()
    {
        IsActive = true;
        _collider = GetComponent<Collider>();
    }

    public override void Interact()
    {
        _collider.enabled = false;
        IsActive = false;
        gameObject.SetActive(false);
        //EventManager.Broadcast(GameEventsHandler.HintCollectEvent);
    }
}
