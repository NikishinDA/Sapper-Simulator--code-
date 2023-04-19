using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BombType
{
    C4,
    DynoRed,
    DynoBrown,
    Hand,
    Airplane,
    Cartoon
}
public class BombSpawnpoint : MonoBehaviour
{
    [SerializeField] private BombLevelObjectController[] bombs;
    [SerializeField] private BombType spawnType;

    public void Spawn()
    {
        Instantiate(bombs[(int) spawnType], transform);
    }

}
