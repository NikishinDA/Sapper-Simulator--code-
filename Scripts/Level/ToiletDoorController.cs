using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletDoorController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int s_open = Animator.StringToHash("open");

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool(s_open, true);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool(s_open, false);

    }
}
