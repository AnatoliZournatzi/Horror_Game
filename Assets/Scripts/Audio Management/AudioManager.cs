/*AudioManager is a class*/

using UnityEngine.Audio;
using System;
using UnityEngine;

//This script is for the audio manager that is going to hold all of the sounds taking place in the game
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; //array with different sounds where each one of them has some specific atttributes.

    void Awake() //awake is like the start 
    {
        //s is the sound that we are currently looking at
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>(); //a new component automatically is generated in the audioManager object in unity for each sound that
            //we have in the array
            s.source.clip = s.clip; //the clip

            s.source.volume = s.volume; //the volume
            s.source.pitch = s.pitch; //and the pitch get copied over there
            s.source.loop = s.loop; // To loop the backround sound

        }
    }

    void Start()
    {
        Play("Background"); //the background sound is going to play from the start to the finish of the game
    }
   
    //The Play method plays a specific sound whenever called
    public void Play(string name) //we make this method public so that we can call it inside from other classes - name: the name of our sound
    {
        //we need to loop through the sounds array to find the sound with this specific name 
        //we could also do that with a foreach loop but we can also do it with the way below (make sure to put using System on the top)
        Sound s = Array.Find(sounds, sound => sound.name == name); //(sound => sound.name == name) we want to find the sound where sound.name equals with name
        s.source.Play(); //if we don't find a sound with the appropriate name its going to throw an error
    }
}
