using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this is a script that is going to load the credits scene after the thank you for playing scene

//!!!this script is only going to work on PLAYMODE NOT on the timeline preview!!!
public class SecondSceneChange : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("CreditsScene", LoadSceneMode.Single);
    }
}

