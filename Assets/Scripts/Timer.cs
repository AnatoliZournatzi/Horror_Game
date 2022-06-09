using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public string LevelToLoad;
    int countDownStartValue = 599; //initialized the variable
    public Text timerUI;

    //Use this for initialization
    void Start()
    {
        countDownTimer();

    }
    void countDownTimer() //** we call this method again after 1 sec,
                          //so this condition will continuously call after 1sec unless the value is grater than 0
    {
        if (countDownStartValue > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue); //initialize this time span span time variable from my counter seconds to minutes
            timerUI.text = "Timer : " + spanTime.Minutes + " : " + spanTime.Seconds; //convert the counter as a timer text
            countDownStartValue--; //decrease the value of this variable 
            Invoke("countDownTimer", 1.0f); // Invoke our method after 1 sec **
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (countDownStartValue <= 0)
        {
            Application.LoadLevel(LevelToLoad); //We load the GameOver Scene
        }
    }
}
