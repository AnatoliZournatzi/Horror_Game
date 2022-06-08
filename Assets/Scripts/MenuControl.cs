using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuControl : MonoBehaviour
{
    public void OpenScene(int index) //Create a public void function with an argument that has an integer variable
    {
        SceneManager.LoadScene(index); //Load the scene that we want. index represent the scenes
    }

    public void ButtonCredits(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ButtonQuit()
    {
        Debug.Log("Quitting game...");
        Application.Quit(); //Close the program
    }
}
