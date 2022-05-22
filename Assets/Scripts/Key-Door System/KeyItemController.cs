using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is going to control what is going to be done when we select either a door or a key

namespace KeySystem { 
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool doorRoomOne = false;
        [SerializeField] private bool keyToRoomOne = false;
        [SerializeField] private bool doorRoomTwo = false;
        [SerializeField] private bool keyToRoomTwo = false;
        [SerializeField] private bool doorRoomThree = false;
        [SerializeField] private bool keyToRoomThree = false;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;

        private void Start()
        {
            doorObject = GetComponent<KeyDoorController>(); //to address the script KeyDoorController that is going to be in the same object as the KeyItemController

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
                _keyInventory.hasKeyToRoomOne = true;
                FindObjectOfType<AudioManager>().Play("PickUpKey");
                gameObject.SetActive(false);
            }

            else if(doorRoomTwo)
            {
                doorObject.PlayAnimation();
            }

            else if (keyToRoomTwo)
            {
                _keyInventory.hasKeyToRoomTwo = true;
                FindObjectOfType<AudioManager>().Play("PickUpKey");
                gameObject.SetActive(false);
            }

            else if (doorRoomThree)
            {
                doorObject.PlayAnimation();
            }

            else if(keyToRoomThree)
            {
                _keyInventory.hasKeyToRoomThree = true;
                FindObjectOfType<AudioManager>().Play("PickUpKey");
                gameObject.SetActive(false);
            }
        }

    }

}