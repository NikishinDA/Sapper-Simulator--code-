using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ToiletAgentController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent firstAgent;
    [SerializeField] private NavMeshAgent secondAgent;
    [SerializeField] private Animator firstAnimator;
    [SerializeField] private Animator secondAnimator;
    [SerializeField] private Transform dest;
    private Vector3 _firstOldPos;
    private Vector3 _secondOldPos;
    private static readonly int s_stop = Animator.StringToHash("stop");
    private static readonly int s_go = Animator.StringToHash("go");

    private void Awake()
    {
        firstAgent.enabled = true;
        secondAgent.enabled = true;
    }

    private void Start()
    {
        _firstOldPos = firstAgent.transform.position;
        _secondOldPos = secondAgent.transform.position;
        StartCoroutine(ActionCor(15f));
    }

    private IEnumerator ActionCor(float wait)
    {
        while (true)
        {
            firstAgent.SetDestination(dest.position);
            for (float t = 0; t < wait; t += Time.deltaTime)
            {
                if (firstAgent.velocity == Vector3.zero)
                {
                    firstAnimator.SetTrigger(s_stop);
                }
                else
                {
                    firstAnimator.SetTrigger(s_go);

                }
                yield return null;
            }

            firstAgent.SetDestination(_firstOldPos);
            
            firstAnimator.ResetTrigger(s_stop);

            firstAnimator.SetTrigger(s_go);

            for (float t = 0; t < wait; t += Time.deltaTime)
            {
                yield return null;
            }

            secondAgent.SetDestination(dest.position);
            for (float t = 0; t < wait;t += Time.deltaTime)
            {
                if (secondAgent.velocity == Vector3.zero)
                {
                    secondAnimator.SetTrigger(s_stop);
                }
                else
                {
                    secondAnimator.SetTrigger(s_go);

                }
                yield return null;
            }

            secondAgent.SetDestination(_secondOldPos);
            secondAnimator.ResetTrigger(s_stop);

            secondAnimator.SetTrigger(s_go);

            for (float t = 0; t < wait; t += Time.deltaTime)
            {
                yield return null;
            }
        }
    }
}
