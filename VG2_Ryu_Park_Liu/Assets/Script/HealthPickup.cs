using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DinoGame{
    public class HealthPickup : MonoBehaviour
    {
        public int amount = 10;

        private void OnTriggerEnter(Collider other) {
            if(other.gameObject.CompareTag("Player")){
                HealthManager healthbar = FindObjectOfType<HealthManager>();
                if(healthbar != null){
                    healthbar.Heal(amount);
                    Destroy(gameObject);
                }
            }
        }
    }
}
