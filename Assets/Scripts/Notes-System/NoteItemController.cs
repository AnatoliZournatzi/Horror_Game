using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A script that is going to control what is going to be done when we find a note and select it using R

namespace NoteSystem {
    public class NoteItemController : MonoBehaviour
    {
        [SerializeField] private bool note = false;
        [SerializeField] private Canvas noteToScreen; //the object that shows the note in 2d mode to the player
        [SerializeField] private KeyCode quitNote = KeyCode.Q;

        private MeshRenderer meshRenderer;
        private Canvas childCanvas;

        void Start()
        {
            meshRenderer = gameObject.GetComponent<MeshRenderer>();
            childCanvas = gameObject.transform.Find("Canvas").GetComponent<Canvas>(); //need this line to shut down the canvas child along with the plane note 
                //when we press R to take the note - can't just set the gameObject not active because we need to still be able to trigger things after we pick it up.
        }

        // Update is called once per frame
        public void ObjectInteraction()
        {
            if(note)
            {
                FindObjectOfType<AudioManager>().Play("NotePick");
                meshRenderer.enabled = false; //make the plane disappear
                childCanvas.enabled = false; //make the text disappear
                noteToScreen.gameObject.SetActive(true);
             
                
                /*gameObject.SetActive(false);*/
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(quitNote))
            {
                noteToScreen.gameObject.SetActive(false);
                FindObjectOfType<AudioManager>().Play("NotePick");
            }
        }
    }
}

