using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//For interacting with specific objects from the game (in this script with doors and keys) we use raycast function which is a Physics function
//which is a function that casts a ray to the scene and returns a boolean value (1 if something was found and 0 if not)
namespace KeySystem
{
    public class KeyRaycast : MonoBehaviour
    {
        [SerializeField] private int rayLength = 2; //the length in which a ray is going to be searching for colliders
        [SerializeField] private LayerMask layerMaskInteract;

        [SerializeField] private string excludeLayerName = null;

        private KeyItemController raycastedObject; //we reference the KeyItemController script
        [SerializeField] private KeyCode openDoorKey = KeyCode.E;

        [SerializeField] private Image interactImage; //reference to the image object in the hierarchy
        [SerializeField] private Sprite crosshairDot; //the sprite with the dot image
        [SerializeField] private Sprite crosshairHand; //the sprite with the scary hand image

        //used a Vector2 object which takes two float values (x,y) - Vector3 has 3 values (x,y,z)
        private Vector2 crosshairHandIconSize = new Vector2(25, 27); //x in the width and y the height in this case
        private Vector2 crosshairDotIconSize = new Vector2(8, 8);

        private bool isCrosshairActive;
        private bool doOnce;

        private string interactableTag = "InteractiveObject";

        private Color dotInactiveColor = new Color(255, 255, 255, 74);
        private Color dotActiveColor = new Color(255, 0, 0, 74);

        private void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value; //to not go through another layer with our ray

            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
            {
                if(hit.collider.CompareTag(interactableTag)) //compare the tag of the object that was casted with the tag of the object that we want to find
                {
                    //we found something at this point
                    if (!doOnce)
                    {
                        raycastedObject = hit.collider.gameObject.GetComponent<KeyItemController>();
                        CrosshairChange(true); //this is where the crosshair changes image
                    }

                    isCrosshairActive = true; //we found a tag (whether we did something or not)
                    doOnce = true;

                    if (Input.GetKeyDown(openDoorKey))
                    {
                        raycastedObject.ObjectInteraction();
                    }
                }
            }
            else
            {
                if(isCrosshairActive)
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
