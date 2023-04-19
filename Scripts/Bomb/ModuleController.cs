using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleController : MonoBehaviour
{
    public Action ModuleComplete;

    protected void CompleteModule()
    {
        ModuleComplete?.Invoke();
    } 
    
}
