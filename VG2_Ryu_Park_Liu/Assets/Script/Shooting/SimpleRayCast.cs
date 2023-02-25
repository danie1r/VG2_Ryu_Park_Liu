using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class SimpleRayCast : MonoBehaviour
{

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            // mouse position in world space
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));

            // direction vector from camera pos to mouse pos
            Vector3 direction = worldMousePosition - Camera.main.transform.position;

            RaycastHit hit;

            if(Physics.Raycast(Camera.main.transform.position, direction, out hit, 100f))
            {
                Debug.DrawLine(Camera.main.transform.position, hit.point, Color.green, 1f);

                if(hit.collider.gameObject.tag == "Enemy")
                {
                Destroy(hit.transform.gameObject);
                }
                else{
                    Debug.Log("Not an enemy");
                }
            }

        }
    }
}
