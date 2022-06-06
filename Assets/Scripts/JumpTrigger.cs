using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public AudioSource voiceAudioSource;
    public AudioClip voiceSound;

    private Animator chairAnimation;

    private bool hasPlayedAudio;
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
            voiceAudioSource.PlayOneShot(voiceSound);
            hasPlayedAudio = true;

            if (hasPlayedAudio = false)
            {
                StartCoroutine(playChairAnimation());
                StartCoroutine(destroyCube());
            }

        }
    }
    IEnumerator playChairAnimation()
    {
        yield return new WaitForSeconds(5);
        chairAnimation.enabled = true;
        FindObjectOfType<AudioManager>().Play("ChairSlide");
        chairAnimation.Play("ChairAnimation", 0, 0.0f);
    }

    IEnumerator destroyCube()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(cubeTrigger);
    }


}
