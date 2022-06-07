using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a script to make background music continue playing
//in between the ThankYouForPLaying and the Credits Scene
public class ContinuePlayingAudio : MonoBehaviour
{
    private static ContinuePlayingAudio instance = null;

    public static ContinuePlayingAudio Instance
    {
        get
        {
            return instance;
        }
    }
    void Start()
    {
        
    }

    private void Awake()
    {

        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
