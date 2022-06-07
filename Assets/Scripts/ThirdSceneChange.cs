using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this is a script that is going to load the main menu scene after the credits scene

//!!!this script is only going to work on PLAYMODE NOT on the timeline preview!!!
public class ThirdSceneChange : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
