using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false; // we created the variable public beacause we want to be accessible from other scripts and Static because we dont want to reference this specific paused menu script
                                             //Create a variable that will keep track of wether or not our game is currently paused

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //We use the ESC key
        {
            if (GameIsPaused) //if the game is already paused
            {
                Resume();  //resume the game
            }
            else //if the game is not currently paused
            {
                Pause(); //paused the game
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); //disable the paused menu
        Time.timeScale = 1f; //Set the time back to normal
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true); //enabled the paused menu
        Time.timeScale = 0f; //freeze time
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit(); //Closed the program
    }
}