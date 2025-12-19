using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs; 
    [SerializeField] GameObject player; 

    IEnumerator Start()
    {
        if(player.GetComponent<Driver>().level == 1)
        {
            do {
                yield return StartCoroutine(SpawnWaveL1());
            } while (true);
        } else
        {
            do {
                yield return StartCoroutine(SpawnWaveL2());
            } while (true);
        }
    }

    IEnumerator SpawnCars(WaveConfig waveConfig)
    {
        for(int i=0;i<waveConfig.AmOfCars();i++) {
            GameObject car =Instantiate(
                waveConfig.GetCar(),
                waveConfig.GetWaypoints()[0].position,
                Quaternion.Euler(0f, 0f, 180f)
            );
            car.GetComponent<MoveCar>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
    IEnumerator SpawnWaveL1()
    {
        for (int i=0;i<4;i++)
        {
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnCars(currentWave));
        }
    }    IEnumerator SpawnWaveL2()
    {
        for (int i=0;i<4;i++)
        {
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnCars(currentWave));
        }
    }
}
