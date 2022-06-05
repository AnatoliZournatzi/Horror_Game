using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//A script that is going to control what is going to be done when we find a note and select it using R

namespace NoteSystem {
    public class NoteItemController : MonoBehaviour
    {
        [SerializeField] private bool note = false;
        [SerializeField] private bool note4 = false;
        [SerializeField] private TMP_Text NoteText2D; //The text mesh pro object of the 2d note that is going to show up in the screen
        [SerializeField] private TMP_Text NoteText3D;
        [SerializeField] private TMP_Text notesFoundUI = null;
        [SerializeField] private GameObject cubeTrigger = null;
        [SerializeField] private GameObject jumpscareGirl = null;
        [SerializeField] private Canvas noteToScreen; //the object that shows the note in 2d mode to the player
        [SerializeField] private KeyCode quitNote = KeyCode.Q;


        private MeshRenderer meshRenderer;
        private Canvas childCanvas;

        private static int noteCounter = 0;

        void Start()
        {
            meshRenderer = gameObject.GetComponent<MeshRenderer>();
            childCanvas = gameObject.transform.Find("Canvas").GetComponent<Canvas>(); //need this line to shut down the canvas child along with the plane note 
            //when we press R to take the note - can't just set the gameObject not active because we need to still be able to trigger things after we pick it up.
        }

        // Update is called once per frame
        public void ObjectInteraction()
        {
            if (note)
            {
                FindObjectOfType<AudioManager>().Play("NotePick");
                meshRenderer.enabled = false; //make the plane disappear
                childCanvas.enabled = false; //make the text disappear
                NoteText2D.text = NoteText3D.text;

                noteCounter++;
                notesFoundUI.text = "Notes Found: " + noteCounter + "/7";

                noteToScreen.gameObject.SetActive(true);

                //from note4 we are going to trigger the activation of the cube that is responsible for a jumpscare
                if (note4)
                {
                    StartCoroutine(waitToHearTheKnock());
                    jumpscareGirl.SetActive(true);
                    cubeTrigger.SetActive(true);
                }

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

        IEnumerator waitToHearTheKnock(){

            yield return new WaitForSeconds(1);
            FindObjectOfType<AudioManager>().Play("DoorKnock");

        }

    }

   
}

