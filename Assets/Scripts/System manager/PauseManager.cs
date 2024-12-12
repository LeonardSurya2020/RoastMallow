using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public Timer timer;
    public bool isPaused;
    public GameObject pauseMenu;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
    }

    public void pauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        //timer.stopTime();
    }

    public void resumeGame()
    {
        if(isPaused == false)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            //timer.continueTime();
        }
    }
}
