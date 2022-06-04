using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndHideGirl : MonoBehaviour
{
    [SerializeField] private GameObject girlFigure;
    [SerializeField] private GameObject cubeTrigger;
    [SerializeField] private GameObject light1;
    [SerializeField] private GameObject light2;
    [SerializeField] private GameObject light3;

    private int timeToShowGirl;

    private Animator girlAnimation;
    private Animator light1Anim;
    private Animator light2Anim;
    private Animator light3Anim;

    // Start is called before the first frame update
    void Start()
    {
        girlAnimation = girlFigure.GetComponent<Animator>();
        light1Anim = light1.GetComponent<Animator>();
        light2Anim = light2.GetComponent<Animator>();
        light3Anim = light3.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //light1Anim.Play("TremblingReceptionLight");
            //light2Anim.Play("TremblingReceptionLight");
            //light3Anim.Play("TremblingReceptionLight");
            FindObjectOfType<AudioManager>().Play("FirstJumpscare");
            girlFigure.SetActive(true);
            StartCoroutine(ShowGirl());
            StartCoroutine(destroyCube());
            /*taskAnimation.Play("slideIn", 0, 0.0f);
            FindObjectOfType<AudioManager>().Play("TaskSound");
            StartCoroutine(showTaskTime());
            //Destroy(cubeTrigger);
            
            StartCoroutine(destroyCube()); //after 3 seconds we destroy the cube because we don't want the same message to be shown again.*/
        }

    }
    IEnumerator ShowGirl()
    {
        
        girlAnimation.Play("girlMoveLeft", 0, 0.0f);
        light1Anim.enabled = false;
        light2Anim.enabled = false;
        light3Anim.enabled = false;
        yield return new WaitForSeconds(3);
        girlFigure.SetActive(false);
    }

    IEnumerator destroyCube()
    {
        yield return new WaitForSeconds(3);
        Destroy(cubeTrigger);
    }
}
