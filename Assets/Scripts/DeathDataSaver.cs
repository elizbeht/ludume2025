using UnityEngine;
using System.Collections.Generic;

public static class DeathDataSaver
{
    public static List<Vector3> deathPositions = new List<Vector3>();

    public static void SaveDeathPosition(Vector3 position)
    {
        deathPositions.Add(position);
    }

    public static List<Vector3> GetDeathPositions()
    {
        return deathPositions;
    }

    public static void ClearDeathPositions()
    {
        deathPositions.Clear();
    }
}