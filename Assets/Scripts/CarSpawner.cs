using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;  

    IEnumerator Start()
    {
        do {
            yield return StartCoroutine(SpawnAllWaves());
        } while (true);
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

    IEnumerator SpawnAllWaves()
    {
        for (int i=0;i<waveConfigs.Count;i++) {
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnCars(currentWave));
        }
    }
}
