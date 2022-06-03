using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public AudioSource laughAudioSource;
    public AudioClip laughSound;

    private bool hasPlayedAudio;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasPlayedAudio == false)
        {
            laughAudioSource.PlayOneShot(laughSound);
            hasPlayedAudio = true;  
        }
    }

  
}
