using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This script is going to control what is going to be done when we select either a door or a key and what is going to happed when we press E

namespace KeySystem { 
    public class KeyItemController : MonoBehaviour
    {
        //variables to help differentiate between keys and door objects
        [SerializeField] private bool doorRoomOne = false;
        [SerializeField] private bool keyToRoomOne = false;
        [SerializeField] private bool doorRoomTwo = false;
        [SerializeField] private bool keyToRoomTwo = false;
        [SerializeField] private bool doorRoomThree = false;
        [SerializeField] private bool keyToRoomThree = false;


        [SerializeField] private TMP_Text keysFoundUI = null;
        [SerializeField] private TMP_Text showKeyClaimUI;
        [SerializeField] private TMP_Text taskUI = null;
        [SerializeField] private GameObject cubeTrigger = null; //the cube to trigger the first jumpscare

        [SerializeField] private KeyInventory _keyInventory = null; //

        private KeyDoorController doorObject; //
        private MeshRenderer meshRenderer; 

        private Animator taskAnimation; //the animator for the tasks

        private static int keyCounter = 0; //if this variable is not static then each object that this script is applied to 
        //would have its own keyCounter (in different places in the memory) so we make it static so that many objects can 
        //alter its value in the same place in memory (they all share the same variable).
        //That way it can be incremented to match the number of keys found.
        private bool keyGainFlag = true;

        private void Start()
        {
            meshRenderer = gameObject.GetComponent<MeshRenderer>(); //from the current object that uses the script we take the meshrenderer component so that we can handle it from the script
            doorObject = GetComponent<KeyDoorController>(); //to address the script KeyDoorController that is going to be in the same object as the KeyItemController
            /*showKeyClaimUI = GetComponent<TMP_Text>(); --- This line of code makes the object to be thrown away and the showKeyClaimUI doesn't have any object*/
            taskAnimation = taskUI.GetComponent<Animator>();
        }

        //this method is going to let us interact with either a door or a key
        public void ObjectInteraction()
        {
            if(doorRoomOne)
            {
                doorObject.PlayAnimation(); 
            }

            else if(keyToRoomOne)
            {
                _keyInventory.hasKeyToRoomOne = true; //when we pick up a key we mark it as taken in the inventory
                FindObjectOfType<AudioManager>().Play("PickUpKey"); //with single line of code we play the sound that follows the event
                /*gameObject.SetActive(false);*/
                meshRenderer.enabled = false; //we disable the rendered to give off the illusion that the key was taken (we don't disable the object yet because 
                //functions that follow up and involve the current object) - after the object is disabled we can't do anyhting with it.
                if (keyGainFlag) 
                {
                    //Key Counter UI update
                    keyCounter++;
                    keysFoundUI.text = "Keys Found: " + keyCounter + "/3";
                    keyGainFlag = false;
                }

                StartCoroutine(showMessageUI("You found key to room 1")); 
                cubeTrigger.SetActive(true); //we activate the first cube trigger

                StartCoroutine(showNewTask("> Find key to room 2"));


            }

            else if(doorRoomTwo)
            {
                doorObject.PlayAnimation();
            }

            else if (keyToRoomTwo)
            {
                _keyInventory.hasKeyToRoomTwo = true;
                FindObjectOfType<AudioManager>().Play("PickUpKey");
                meshRenderer.enabled = false;

                if (keyGainFlag)
                {
                    //Key Counter UI update
                    keyCounter++;
                    keysFoundUI.text = "Keys Found: " + keyCounter + "/3";
                    keyGainFlag = false;
                }

                StartCoroutine(showMessageUI("You found key to room 2"));
                /*gameObject.SetActive(false);*/

                StartCoroutine(showNewTask("> Find key to room 3"));
            }

            else if (doorRoomThree)
            {
                doorObject.PlayAnimation();
            }

            else if(keyToRoomThree)
            {
                _keyInventory.hasKeyToRoomThree = true;
                FindObjectOfType<AudioManager>().Play("PickUpKey");
                meshRenderer.enabled = false;

                if (keyGainFlag)
                {
                    //Key Counter UI update
                    keyCounter++;
                    keysFoundUI.text = "Keys Found: " + keyCounter + "/3";
                    keyGainFlag = false;
                }
                StartCoroutine(showMessageUI("You found key to room 3"));
            }

        }

        IEnumerator showMessageUI(string messageText)
        {
            showKeyClaimUI.text = messageText; 
            showKeyClaimUI.gameObject.SetActive(true); //to set active an object that is not of type GameObject (in our situation it is TMP_Text) 
                                                       //we need to put the nameOfTheObject.gameObject.SetActive(true);
                                                       //i think this casts the object into its general type of GameObject and it can use its 
                                                       //functions like setActive state etc.

            yield return new WaitForSeconds(1.8f);
            showKeyClaimUI.gameObject.SetActive(false);
        }

        IEnumerator showNewTask(string taskText)
        {
            taskUI.text = taskText;
            yield return new WaitForSeconds(1.5f);
            taskAnimation.Play("slideIn", 0, 0.0f);
            FindObjectOfType<AudioManager>().Play("TaskSound");
            yield return new WaitForSeconds(3);
            taskAnimation.Play("slideOut", 0, 0.0f);
        }

       
    }

}