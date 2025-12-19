using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject moneySpawner;
    public void Update()
    {
        if (player.GetComponent<Driver>().dead)
        {
            LoadGameOver();
            return;
        }
        if (moneySpawner.GetComponent<MoneySpawner>().finished)
        {
            StaticScoreAndHealth.score = player.GetComponent<Driver>().score;
            StaticScoreAndHealth.health = player.GetComponent<Driver>().health;
            if(player.GetComponent<Driver>().level == 2)
            {
                LoadWin();
                return;
            }
            LevelIntermission();
            return; 
        }
    }

    public void LoadStart()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");

    }
    public void LevelIntermission()
    {
        SceneManager.LoadScene("LevelIntermission");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }    
    public void LoadWin()
    {
        SceneManager.LoadScene("Win");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
