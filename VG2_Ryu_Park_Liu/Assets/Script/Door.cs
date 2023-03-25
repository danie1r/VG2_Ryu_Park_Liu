using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DinoGame
{
    public class Door : MonoBehaviour
    {
        Animator animator;
        public int keyIdRequired;
        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Interact()
        {
            print("Interacted");
            bool shouldOpen = false;
            bool hasKey = PlayerController.instance.keyIdsObtained.Contains(keyIdRequired);
            if (hasKey)
            {
                shouldOpen = true;
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

