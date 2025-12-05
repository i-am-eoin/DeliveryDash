using UnityEngine;
using System.Collections.Generic;

public class MoveCar : MonoBehaviour
{
    [SerializeField] WaveConfig waveConfig;
    int currentWaypoint = 0;

    void Start()
    {
        if (waveConfig != null)
        {
            transform.position = waveConfig.GetWaypoints()[currentWaypoint].transform.position;
        }

    }
    void Update()
    {
        CarMove();
    }
    
    void CarMove()
    {
        if (currentWaypoint < waveConfig.GetWaypoints().Count) {
        var targetPosition = waveConfig.GetWaypoints()[currentWaypoint].transform.position;        
        targetPosition.z = 0f;
        
        var movementThisFrame = waveConfig.GetCarSpeed() * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

        if (transform.position == targetPosition)
        {
            currentWaypoint++;
        }
        } else {
            Destroy(gameObject);
        }
    }
    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
        if (waveConfig != null)
        {
            transform.position = waveConfig.GetWaypoints()[currentWaypoint].transform.position;
        }
    }
}