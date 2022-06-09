using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This script is going to control the movement of the door
namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        private Animator doorAnim;
        private bool doorOpen = false;

        

        [Header("Animation Names")]
        [SerializeField] private string openAnimationName = null;
        //[SerializeField] private string closeAnimationName = "Close";

        [SerializeField] private int timeToShowUI = 1;

        [SerializeField] private TMP_Text showDoorIsLockedUI;

        [SerializeField] private KeyInventory _keyInventory = null;

        [SerializeField] private int waitTimer = 1;
        [SerializeField] private bool pauseInteraction = false;

        [SerializeField] private bool isDoorOne = false;
        [SerializeField] private bool isDoorTwo = false;
        [SerializeField] private bool isDoorThree = false;

        private void Awake()
        {
            doorAnim = gameObject.GetComponent<Animator>(); //this is going to auto fill the animation so we dont need to look for or add that to the inspector
        }

        private IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }

        public void PlayAnimation()
        {
            if (_keyInventory.hasKeyToRoomOne && isDoorOne)
            {
                OpenDoor(); 
            }
            else if (_keyInventory.hasKeyToRoomTwo && isDoorTwo)
            {
                OpenDoor();
            }
            else if (_keyInventory.hasKeyToRoomThree && isDoorThree)
            {
                OpenDoor();
            }

            else
            {
                StartCoroutine(showDoorIsLocked("It's locked..."));
                FindObjectOfType<AudioManager>().Play("LockedDoor");
            }
        }

        void OpenDoor()
        {
            if (!doorOpen && !pauseInteraction)
            {
                doorAnim.Play(openAnimationName, 0, 0.0f);
                FindObjectOfType<AudioManager>().Play("DoorOpenSound1");
                doorOpen = true;
                StartCoroutine(PauseDoorInteraction());
            }
            
        }

        IEnumerator showDoorIsLocked(string messageText)
        {
            showDoorIsLockedUI.text = messageText;
            showDoorIsLockedUI.gameObject.SetActive(true); //to set active an object that is not of type GameObject (in our situation it is TMP_Text) 
                                                       //we need to put the nameOfTheObject.gameObject.SetActive(true);
                                                       //i think this casts the object into its general type of GameObject and it can use its 
                                                       //functions like setActive state etc.

            yield return new WaitForSeconds(1.8f);
            showDoorIsLockedUI.gameObject.SetActive(false);
        }

    }
}
