using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrawerSystem
{
    public class DrawerItemController : MonoBehaviour
    {

        private Animator drawerAnim; //the animator of the drawer object
        private bool drawerOpen = false;

        [Header("Animation Names")]
        [SerializeField] private string openAnimationName = null;
        [SerializeField] private string closeAnimationName = null;
        private void Awake()
        {
            drawerAnim = gameObject.GetComponent<Animator>();
        }

        public void ObjectInteraction()
        {
            if (!drawerOpen)
            {
                drawerAnim.Play(openAnimationName, 0, 0.0f);
                FindObjectOfType<AudioManager>().Play("DrawerOpenClose");
                drawerOpen = true;
            }
            else
            {
                drawerAnim.Play(closeAnimationName, 0, 0.0f);
                FindObjectOfType<AudioManager>().Play("DrawerOpenClose");
                drawerOpen = false;
            }
            
        }
    }

}
