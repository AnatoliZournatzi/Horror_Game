using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public string LevelToLoad;
    int countDownStartValue = 299;
    public Text timerUI;

    // Start is called before the first frame update
    void Start()
    {
        countDownTimer();

    }
    void countDownTimer()
    {
        if (countDownStartValue > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
            timerUI.text = "Timer : " + spanTime.Minutes + " : " + spanTime.Seconds;
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {

            timerUI.text = "GameOver!";
            

        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (countDownStartValue <= 0)
        {
            Application.LoadLevel(LevelToLoad);
        }
    }
}
