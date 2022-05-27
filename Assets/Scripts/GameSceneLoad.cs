using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this is a script that is going to load the main game scene after the end of the storyline

//!!!this script is only going to work on PLAYMODE NOT on the timeline preview!!!
public class GameSceneLoad : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
