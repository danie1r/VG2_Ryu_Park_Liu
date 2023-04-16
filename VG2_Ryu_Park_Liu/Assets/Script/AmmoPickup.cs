using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DinoGame{
    public class AmmoPickup : MonoBehaviour
{
    public int amount = 50;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            GUN Ammo = FindObjectOfType<GUN>();
            if(Ammo){
                Ammo.AddAmmo(amount);
                Debug.Log("Ammo Added Successfully");
                Destroy(gameObject);
            }
        }
    }
}

}
