using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BombLevelObjectController : InteractiveObject
{
    private Collider _collider;

    private void Awake()
    {
        IsActive = true;
        _collider = GetComponent<Collider>();
    }

    public override void Interact()
    {
        var evt = GameEventsHandler.BombFoundEvent;
        evt.BombObject = this;
        EventManager.Broadcast(evt);
    }

    public void Defuse()
    {
        _collider.enabled = false;
        IsActive = false;
        gameObject.SetActive(false);
        //EventManager.Broadcast(GameEventsHandler.BombDefuseEvent);
    }
}
