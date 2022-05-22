using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KeySystem
{
    public class KeyRaycast : MonoBehaviour
    {
        [SerializeField] private int rayLength = 2; //the length in which a ray is going to be searching for colliders
        [SerializeField] private LayerMask layerMaskInteract;

        [SerializeField] private string excludeLayerName = null;

        private KeyItemController raycastedObject;
        [SerializeField] private KeyCode openDoorKey = KeyCode.E;

        [SerializeField] private Image crosshair = null;
        private bool isCrosshairActive;
        private bool doOnce;

        private string interactableTag = "InteractiveObject";

        private void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value; //to not go through another layer with our ray

            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
            {
                if(hit.collider.CompareTag(interactableTag))
                {
                    //we found something at this point
                    if (!doOnce)
                    {
                        raycastedObject = hit.collider.gameObject.GetComponent<KeyItemController>();
                        CrosshairChange(true); 
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
            if(on && !doOnce)
            {
                crosshair.color = Color.red; 
            }
            else
            {
                crosshair.color = Color.white;
                isCrosshairActive = false;
            }
        }


    }
}
