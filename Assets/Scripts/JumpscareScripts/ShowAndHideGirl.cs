using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndHideGirl : MonoBehaviour
{
    private static bool firstJumpFlag = true; //if the first jumpscare collider was active and the first jumpscare happened 
    //then don't let the first jumpscare's process happen again.
    [SerializeField] private GameObject girlFigure;
    [SerializeField] private GameObject cubeTrigger;
    [SerializeField] private string jumpscareAnimationName;
   

    private int timeToShowGirl;

    private Animator girlAnimation;
    

    // Start is called before the first frame update
    void Start()
    {
        girlAnimation = girlFigure.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (firstJumpFlag) {
                FindObjectOfType<AudioManager>().Play("FirstJumpscare");
                girlFigure.SetActive(true);
                StartCoroutine(ShowGirl());
                StartCoroutine(destroyCube());//after 3 seconds we destroy the cube because we don't want the same message to be shown again.*/
                firstJumpFlag = false;
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("SecondJumpscare");
                girlAnimation.enabled = true;
                StartCoroutine(secondJumpscareAnimation());
                StartCoroutine(destroyCube());
            }
        }

    }
    IEnumerator ShowGirl()
    {
        
        girlAnimation.Play("girlMoveLeft", 0, 0.0f);
        yield return new WaitForSeconds(2);
        girlFigure.SetActive(false);
    }

    IEnumerator secondJumpscareAnimation()
    {
        girlAnimation.Play("secondGirlMoveLeft", 0, 0.0f);
        yield return new WaitForSeconds(2);
        girlFigure.SetActive(false);
    }

    IEnumerator destroyCube()
    {
        yield return new WaitForSeconds(3);
        Destroy(cubeTrigger);
    }
}
