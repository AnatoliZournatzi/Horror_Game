using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this is a script that is going to load the menu scene after the end of the game over scene

//!!!this script is only going to work on PLAYMODE NOT on the timeline preview!!!
public class GameOverToMenuChange : MonoBehaviour
{
    private void OnEnable()
    {
        Application.Quit();
    }
}

