using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DinoGame
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController instance;
        public List<int> keyIdsObtained;
        void Awake()
        {
            instance = this;
            keyIdsObtained = new List<int>();
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Keyboard keyboardInput = Keyboard.current;
            Mouse mouseInput = Mouse.current;
            if (keyboardInput != null && mouseInput != null)
            {
                if (keyboardInput.eKey.wasPressedThisFrame)
                {
                    Vector2 mousePosition = mouseInput.position.ReadValue();
                    Ray ray = Camera.main.ScreenPointToRay(mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 2f))
                    {
                        print("Interaction");
                        Door targetdoor = hit.transform.GetComponent<Door>();
                        if (targetdoor)
                        {
                            targetdoor.Interact();
                        }

                        InteractEnd dna = hit.transform.GetComponent<InteractEnd>();
                        if (dna)
                        {
                            dna.Interact();
                        }
                    }
                }
            }
        }
    }
}

