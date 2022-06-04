using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TremblingLight : MonoBehaviour
{
    [SerializeField] private Light[] pointLights; //an array that is goinf to contain all the point lights
    private Animator lightAnim;

    [SerializeField] private string tremblingLightAnimationName = null;

    private void Awake()
    {
       lightAnim  = gameObject.GetComponent<Animator>();
    }

    void FlickerLights()
    {
        foreach(Light l in pointLights)
        {
            lightAnim.Play(tremblingLightAnimationName, 0, 0.0f);
        }
    }
}
