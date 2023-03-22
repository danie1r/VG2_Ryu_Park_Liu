using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

namespace DinoGame
{
    public class SimpleRayCast : MonoBehaviour
    {
        public int dinoKillCount;
        public TMP_Text killCount;
        
        void Start()
        {
            dinoKillCount = 0;
            killCount.text = "Kill Points: " + dinoKillCount.ToString();
        }
        void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                // mouse position in world space
                Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));

                // direction vector from camera pos to mouse pos
                Vector3 direction = worldMousePosition - Camera.main.transform.position;

                RaycastHit hit;

                if (Physics.Raycast(Camera.main.transform.position, direction, out hit, 100f))
                {
                    Debug.DrawLine(Camera.main.transform.position, hit.point, Color.green, 1f);

                    GameObject hitObject = hit.collider.gameObject;
                    if (hitObject.tag == "Enemy")
                    {
                        //We can differentiate points for different dinosaurs here
                        if (hitObject.name.Contains("Raptor 1"))
                        {
                            dinoKillCount += 100;
                        }
                        killCount.text = "Kill Points: " + dinoKillCount.ToString();
                        Destroy(hit.transform.gameObject);
                    }
                    else
                    {
                        Debug.Log("Not an enemy");
                    }
                }

            }
        }
    }

}
