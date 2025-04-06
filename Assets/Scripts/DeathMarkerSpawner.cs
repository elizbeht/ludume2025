using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeathMarkerSpawner : MonoBehaviour
{
    public GameObject gravePrefab;

    void Start()
    {
        List<Vector3> deathPositions = DeathDataSaver.GetDeathPositions();
        foreach (Vector3 deathPosition in deathPositions)
        {
            Instantiate(gravePrefab, deathPosition, Quaternion.identity);
        }
        // DeathDataSaver.ClearDeathPositions();
    }
}