using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DinoGame 
{
    public class AmmoPickup : MonoBehaviour {
        private void OnTriggerEnter(Collider collision) {
                GUN weapon = collision.gameObject.GetComponent<GUN>();
                if (weapon && collision.CompareTag("Player")) {
                weapon.currentAmmo = weapon.maxAmmo;
                }                
                Destroy(gameObject);
        }
    }
}