using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NoteSystem
{
    public class NoteRaycast : MonoBehaviour
    {
        [SerializeField] private int rayLength = 2; //the length in which a ray is going to be searching for colliders
        [SerializeField] private LayerMask layerMaskInteract;

        [SerializeField] private string excludeLayerName = null;

        private NoteItemController raycastedObject;
        [SerializeField] private KeyCode pickUpNote = KeyCode.E;

        [SerializeField] private Image interactImage; //reference to the image object in the hierarchy
        [SerializeField] private Sprite crosshairDot; //the sprite with the dot image
        [SerializeField] private Sprite crosshairHand; //the sprite with the scary hand image

        //used a Vector2 object which takes two float values (x,y) - Vector3 has 3 values (x,y,z)
        private Vector2 crosshairHandIconSize = new Vector2(25, 27); //x in the width and y the height in this case
        private Vector2 crosshairDotIconSize = new Vector2(8, 8);

        private bool isCrosshairActive;
        private bool doOnce;

        private string interactableTag = "NoteObject";

        private void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value; //to not go through another layer with our ray

            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
            {
                if (hit.collider.CompareTag(interactableTag))
                {
                    //we found something at this point
                    if (!doOnce)
                    {
                        raycastedObject = hit.collider.gameObject.GetComponent<NoteItemController>();
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true; //we found a tag (whether we did something or not)
                    doOnce = true;

                    if (Input.GetKeyDown(pickUpNote))
                    {
                        raycastedObject.ObjectInteraction();
                    }
                }
            }
            else
            {
                if (isCrosshairActive)
                {
                    CrosshairChange(false);
                    doOnce = false;
                }
            }
        }

        void CrosshairChange(bool on)
        {
            if (on && !doOnce)
            {
                interactImage.rectTransform.sizeDelta = crosshairHandIconSize; //with this we transform the size of the hand image to be 25 x 25
                interactImage.sprite = crosshairHand;
            }
            else
            {
                interactImage.rectTransform.sizeDelta = crosshairDotIconSize;
                interactImage.sprite = crosshairDot;
                isCrosshairActive = false;
            }
        }


    }
}
