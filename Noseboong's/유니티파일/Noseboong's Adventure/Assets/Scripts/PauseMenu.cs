using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIspaused = false;

    public GameObject PauseMenuUI;

    public void PauseBtnDown()
    {
        if (GameIspaused)
            Resume();
        else
            Pause();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIspaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIspaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIspaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
