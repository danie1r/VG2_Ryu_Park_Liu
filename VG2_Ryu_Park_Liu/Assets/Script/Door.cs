using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DinoGame
{
    public class Door : MonoBehaviour
    {
        Animator animator;
        public int keyIdRequired = -1;

        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Interact()
        {
            bool shouldOpen = true;
            bool keyRequired = keyIdRequired >= 0;
            bool keyMissing = !PlayerController.instance.keyIdsObtained.Contains(keyIdRequired);
            if (keyRequired && keyMissing)
            {
                shouldOpen = false;
            }

            if (shouldOpen)
            {
                animator.SetTrigger("Open");
            }
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

