using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
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

public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
