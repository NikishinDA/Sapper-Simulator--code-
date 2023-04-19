using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombHolderController : MonoBehaviour
{
    private void Awake()
    {
        EventManager.AddListener<BombActivateEvent>(OnBombActivate);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<BombActivateEvent>(OnBombActivate);
    }

    private void OnBombActivate(BombActivateEvent obj)
    {
        obj.BombTransform.SetParent(transform);
        obj.BombTransform.GetComponent<ItemRotationController>().SetDimension();
        StartCoroutine(PullBomb(obj.BombTransform, 1f));
    }

    private IEnumerator PullBomb(Transform bombTransform, float time)
    {
        Vector3 oldPos = bombTransform.localPosition;
        for (float t = 0; t < time; t += Time.deltaTime)
        {
            bombTransform.localPosition = Vector3.Lerp(oldPos, Vector3.zero, t/time);
            yield return null;
        }
        bombTransform.localPosition = Vector3.zero;
        
    }
}
