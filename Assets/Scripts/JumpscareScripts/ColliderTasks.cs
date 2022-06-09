using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to show UI after hitting a collider - be sure the collider isTrigger is CHECKED!!!!!!!
public class ColliderTasks : MonoBehaviour
{
    [SerializeField] private GameObject taskText;
    [SerializeField] private GameObject cubeTrigger;

    [SerializeField] private int timeToShowTask; //wait for 2 seconds to show to task

    private Animator taskAnimation;

    private void Start()
    {
        taskAnimation = taskText.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            taskAnimation.Play("slideIn", 0, 0.0f);
            FindObjectOfType<AudioManager>().Play("TaskSound");
            StartCoroutine(showTaskTime());
            //Destroy(cubeTrigger);
            StartCoroutine(destroyCube()); //after 3 seconds we destroy the cube because we don't want the same message to be shown again.
        }

    }

    IEnumerator showTaskTime()
    {
        yield return new WaitForSeconds(timeToShowTask);
        taskAnimation.Play("slideOut", 0, 0.0f);
    }

    IEnumerator destroyCube()
    {
        yield return new WaitForSeconds(3);
        Destroy(cubeTrigger);
    }
}
