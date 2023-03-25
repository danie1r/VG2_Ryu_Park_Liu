using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace DinoGame
{
    public class MenuController : MonoBehaviour
    {
        public static MenuController instance;
        public TMP_Text alert;

        private void Awake()
        {
            instance = this;
            Hide();
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Show()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
            PlayerController.instance.isPaused = true;
        }
        public void Hide()
        {
            alert.enabled = false;      
            gameObject.SetActive(false);
            Time.timeScale = 1;
            if (PlayerController.instance != null)
            {
                PlayerController.instance.isPaused = false;
            }
        }
    }
}

