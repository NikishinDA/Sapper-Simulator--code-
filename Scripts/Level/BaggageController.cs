using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaggageController : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private int startWaypoint;
    [SerializeField] private float speed;
    private int _nextPoint;
    private int _prevPoint;
    private float _progress;
    private void Awake()
    {
        _nextPoint = (startWaypoint + 1) % waypoints.Length;
        _prevPoint = startWaypoint;
        float dist2Point = Vector3.Distance(waypoints[_nextPoint].position, waypoints[startWaypoint].position);
        float dist2Holder = Vector3.Distance(transform.position, waypoints[startWaypoint].position);
        _progress = dist2Holder / dist2Point;
        if (_progress > 1f)
        {
            Debug.LogError("Wrong position");
        }
    }

    private void Update()
    {
        if (_progress >= 1)
        {
            _prevPoint = _nextPoint;
            _nextPoint++;
            _nextPoint %= waypoints.Length;
            _progress = 0;
        }

        transform.position = Vector3.Lerp(waypoints[_prevPoint].position, waypoints[_nextPoint].position, _progress);
        _progress += speed * Time.deltaTime;
    }
}
