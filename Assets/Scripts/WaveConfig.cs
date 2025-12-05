using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "Car_WaveConfig")]

public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject carPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfCars = 5;
    [SerializeField] float carSpeed = 2f;

    public GameObject GetCar() 
    {
        return carPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        var waveWayPoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }
        
        return waveWayPoints;
    }


    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int AmOfCars()
    {
        return numberOfCars;
    }
    public float GetCarSpeed()
    {
        return carSpeed;
    }

}
