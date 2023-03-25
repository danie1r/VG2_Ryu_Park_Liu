using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DinoGame
{
    public class WeaponPickup : MonoBehaviour
    {

        public TMP_Text alertMessage;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>())
            {
                if (gameObject.name.Contains("Sniper"))
                {
                    if (PlayerController.instance.dinoKillCount - 1500 >= 0)
                    {
                        alertMessage.text = "";
                        WeaponSwitching.instance.sniper = true;
                        PlayerController.instance.dinoKillCount -= 1500;
                        Destroy(gameObject);
                    }
                    else
                    {
                        alertMessage.text = "You must have over 1500 points to use the Sniper";
                    }

                } 
                else if (gameObject.name.Contains("Rifle"))
                {
                    if (PlayerController.instance.dinoKillCount - 1000 >= 0)
                    {
                        alertMessage.text = "";
                        WeaponSwitching.instance.rifle = true;
                        PlayerController.instance.dinoKillCount -= 1000;
                        Destroy(gameObject);
                    }
                    else
                    {
                        alertMessage.text = "You must have over 1000 points to use the Rifle";
                    }

                }
            }
        }
    }
}

