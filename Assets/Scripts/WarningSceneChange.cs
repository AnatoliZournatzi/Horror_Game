using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this is a script that is going to load the storyline scene after the end of the warning scene


//!!!this script is only going to work on PLAYMODE NOT on the timeline preview!!!
public class WarningSceneChange : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("StoryTimeScene", LoadSceneMode.Single);
    }
}
