using UnityEngine;

public class LoadData : MonoBehaviour
{
    [SerializeField] Driver driver;
    void Start()
    {
        driver.score = StaticScoreAndHealth.score;
        driver.health = StaticScoreAndHealth.health;
    }

}
