using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public AudioSource voiceAudioSource;
    public AudioClip voiceSound;

    private Animator chairAnimation;

    private bool hasPlayedAudio = false;
    [SerializeField] private GameObject chairFigure;
    [SerializeField] private GameObject cubeTrigger;

    void Start()
    {
        chairAnimation = chairFigure.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasPlayedAudio == false)
        {
            
            StartCoroutine(playChairAnimation());
            //StartCoroutine(destroyCube());
           
        }
    }
    IEnumerator playChairAnimation()
    {
        Debug.Log("Playing chair animation");
        yield return new WaitForSeconds(1);
        chairAnimation.enabled = true;
        FindObjectOfType<AudioManager>().Play("ChairSlide");
        chairAnimation.Play("ChairAnimation", 0, 0.0f);
        yield return new WaitForSeconds(1.5f);
        voiceAudioSource.PlayOneShot(voiceSound);
        hasPlayedAudio = true;
        //yield return new WaitForSeconds(2);
        //Destroy(cubeTrigger);
    }

    IEnumerator destroyCube()
    {
        yield return new WaitForSeconds(2);
        Destroy(cubeTrigger);
    }



}
