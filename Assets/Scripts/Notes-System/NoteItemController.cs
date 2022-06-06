using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//A script that is going to control what is going to be done when we find a note and select it using R

namespace NoteSystem {
    public class NoteItemController : MonoBehaviour
    {
        //bools to specific notes that are a trigger to something
        [SerializeField] private bool note = false;
        [SerializeField] private bool note4 = false;
        [SerializeField] private bool note6 = false;
        [SerializeField] private bool note7 = false;

        [SerializeField] private TMP_Text NoteText2D; //The text mesh pro object of the 2d note that is going to show up in the screen
        [SerializeField] private TMP_Text NoteText3D;
        [SerializeField] private TMP_Text notesFoundUI = null;
        [SerializeField] private GameObject cubeTrigger = null;
        [SerializeField] private GameObject jumpscareGirl = null;
        [SerializeField] private Canvas noteToScreen; //the object that shows the note in 2d mode to the player
        [SerializeField] private KeyCode quitNote = KeyCode.Q;

        [SerializeField] private GameObject lastNote = null;
        [SerializeField] private TMP_Text taskUI = null;


        private MeshRenderer meshRenderer;
        private Canvas childCanvas;

        private static int noteCounter = 0;
        private bool noteGainFlag = true;

        private Animator taskAnimation;

        void Start()
        {
            meshRenderer = gameObject.GetComponent<MeshRenderer>();
            childCanvas = gameObject.transform.Find("Canvas").GetComponent<Canvas>(); //need this line to shut down the canvas child along with the plane note 
            //when we press R to take the note - can't just set the gameObject not active because we need to still be able to trigger things after we pick it up.
            taskAnimation = taskUI.GetComponent<Animator>();
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


                if (noteGainFlag)
                {
                    noteCounter++;
                    notesFoundUI.text = "Notes Found: " + noteCounter + "/7";
                    noteGainFlag = false;
                }

                noteToScreen.gameObject.SetActive(true);

                //from note4 we are going to trigger the activation of the cube that is responsible for a jumpscare
                if (note4)
                {
                    StartCoroutine(waitToHearTheKnock());
                    jumpscareGirl.SetActive(true);
                    cubeTrigger.SetActive(true);
                }
                if (Input.GetKeyDown(quitNote))
                {
                    noteCounter++;
                    notesFoundUI.text = "Notes Found: " + noteCounter + "/7";
                    noteGainFlag = false;
                }

                if (note6)
                {
                    lastNote.SetActive(true);
                    StartCoroutine(showNewTask("> Find the last note"));
                }

                if(note7)
                {
                    StartCoroutine(showNewTask("> Completed first chapter"));
                    StartCoroutine(loadEndingScene());
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

        IEnumerator showNewTask(string taskText)
        {
            taskUI.text = taskText;
            yield return new WaitForSeconds(1.5f);
            taskAnimation.Play("slideIn", 0, 0.0f);
            FindObjectOfType<AudioManager>().Play("TaskSound");
            yield return new WaitForSeconds(3);
            taskAnimation.Play("slideOut", 0, 0.0f);
        }

        IEnumerator loadEndingScene()
        {
            yield return new WaitForSeconds(8);
            SceneManager.LoadScene("ThankYouScene", LoadSceneMode.Single);
        }
    }


}

