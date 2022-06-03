/*This sound */

using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{ 
    public string name; //the name of the audio clip

    public AudioClip clip; //reference to the audio clip

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    public bool loop; //Loop the Background Sound

    [HideInInspector]
    public AudioSource source; //variable to contain the audio source so that when we want to play the sound we can call the play method on the audio source
   
}
