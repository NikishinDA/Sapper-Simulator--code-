using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{

    public bool IsActive
    {
        get;
        protected set;
    }
    public abstract void Interact();
}