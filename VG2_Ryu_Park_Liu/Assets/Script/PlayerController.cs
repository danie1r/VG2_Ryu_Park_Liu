using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;

namespace DinoGame
{
    public class PlayerController : MonoBehaviour
    {
        public GameObject dinosaur;
        public static PlayerController instance;
        public List<int> keyIdsObtained;
        public GameObject spawner;
        public int dinoKillCount;
        public TMP_Text dinoPointText;
        public Image minimap;
        private bool mapExpand = false;
        private Transform originalPosition;
        //public TMP_Text weaponPointsText; //points text displayed in weapons menu
        //public TMP_Text NoPointAlert;
        //public Button RifleButton;
        //public TMP_Text RifleText;

        //public Button SniperButton;
        //public TMP_Text SniperText;

        public bool isPaused;   
        public Transform currentLocation;
        void Awake()
        {
            instance = this;
            keyIdsObtained = new List<int>();
            currentLocation = transform;
            dinoKillCount = 0;
        }
        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Escape))
            //{
            //    if (!isPaused)
            //    {
            //        MenuController.instance.Show();
            //    }
            //    else
            //    {
            //        MenuController.instance.Hide();
            //    }
            //}
            //if (isPaused)
            //{
            //    return;
            //}

            
            
            dinoPointText.text = "Points: " + (dinoKillCount).ToString();
            //weaponPointsText.text = dinoPointText.text;

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

            if (FindObjectOfType<DinoMovement>() == false)
            {
                spawner.GetComponent<DinoSpawn>().SpawnAgain();
            }


            if (mapExpand && Input.GetKeyDown(KeyCode.M)) // expands the map
            {
                Vector3 newScale = new Vector3(1.527926f, 1.527926f, 1.527926f);
                minimap.transform.localScale = newScale;
                minimap.transform.localPosition = new Vector3(-536f, -233.81f, 0f);
                mapExpand = false;
            } else if (!mapExpand && Input.GetKeyDown(KeyCode.M))
            {
                // Debug.Log(minimap.transform.localPosition);
                Vector3 newScale = new Vector3(4f, 4f, 4f);
                minimap.transform.localScale = newScale;
                minimap.transform.localPosition = new Vector3(25f, 0f, 25f);
                mapExpand = true;
            }

            
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseMenu.instance.Show();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            if (Input.GetKeyDown(KeyCode.O) && isPaused)
            {
                PauseMenu.instance.Hide();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

            }

            if (Input.GetKeyDown(KeyCode.P) && isPaused)
            {
                PauseMenu.instance.Restart();

            }
            
            if (isPaused)
            {
                return;
            }


            


            //GetComponent.FirstPersonController.enable == false;

        }

        //public void BuyRifle()
        //{
        //    print("Clicked");
        //    if (dinoKillCount - 1000 < 0)
        //    {
        //        NoPointAlert.enabled = true;
        //    }
        //    else
        //    {
        //        NoPointAlert.enabled = false;
        //        dinoKillCount -= 1000;
        //        RifleButton.interactable = false;
        //        RifleText.text = "Bought!";
        //        weaponPointsText.text = "Points: " + (dinoKillCount).ToString();
        //    }

        //}

        //public void BuySniper()
        //{
        //    if (dinoKillCount - 1500 < 0)
        //    {
        //        NoPointAlert.enabled = true;
        //    }
        //    else
        //    {
        //        NoPointAlert.enabled = false;
        //        dinoKillCount -= 1500;
        //        SniperButton.interactable = false;
        //        SniperText.text = "Bought!";
        //        weaponPointsText.text = "Points: " + (dinoKillCount).ToString();
        //    }
        //}

    }
}

