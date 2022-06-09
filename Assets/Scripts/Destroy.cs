using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    //with this way we simple remove the audio from the scene when you finished playing
    private void Start()
    {
        Destroy(gameObject, 3f); //This gameObject will be destroyed after 3 sec
    }

}
