using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DinoGame{
    public class HealthPickup : MonoBehaviour
    {
        public int amount = 10;
        public AudioClip healthPickupSound; // Audio clip to play


        private void OnTriggerEnter(Collider other) {
            if(other.gameObject.CompareTag("Player")){
                HealthManager healthbar = FindObjectOfType<HealthManager>();
                if(healthbar != null){
                    healthbar.Heal(amount);
                    AudioSource.PlayClipAtPoint(healthPickupSound, transform.position);
                    Destroy(gameObject);
                }
            }
        }
    }
}
