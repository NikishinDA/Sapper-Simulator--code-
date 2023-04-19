using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bombObject;
    [SerializeField] private BombSpawnpoint[] spawnPoints;
    [SerializeField] private int spawnNumbers;

    private List<BombSpawnpoint> _pointList;
    [Header("Debug")] [SerializeField] private bool spawnAll;

    private void Awake()
    {
        _pointList = new List<BombSpawnpoint>(spawnPoints);
    }

    private void Start()
    {
        if (spawnAll)
        {
            foreach (var spawnpoint in _pointList)
            {
                spawnpoint.Spawn();
            }
        }
        for (int i = 0; i < spawnNumbers; i++)
        {
            int rand = Random.Range(0, _pointList.Count);
            _pointList[rand].Spawn();
            _pointList.RemoveAt(rand);
        }
    }
}
