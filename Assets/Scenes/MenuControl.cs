using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuControl : MonoBehaviour
{
    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ButtonCredits(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}
