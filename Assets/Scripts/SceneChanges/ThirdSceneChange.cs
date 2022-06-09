using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this is a script that is going to exit the game after the credits - after the player has completed the chapter 1 of the game

//!!!this script is only going to work on PLAYMODE NOT on the timeline preview!!!
public class ThirdSceneChange : MonoBehaviour
{
    private void OnEnable()
    {
        Application.Quit();
    }
}
