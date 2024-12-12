using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    public void playGame()
    {
        SceneManager.LoadScene("playGround");
    }

    public void helpMenu()
    {
        SceneManager.LoadScene("helpMenu");
    }

    public void aboutMenu()
    {
        SceneManager.LoadScene("aboutMenu");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void retryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("playGround");
        
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("menu");
    }

}
