using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

namespace DinoGame{
    public class GUN : MonoBehaviour
    {
        public float damage = 10f;
        public float range = 100f;
        public float fireRate = 15f;
        //ammo count system
        public int currentClip = 20;
        public int maxClip = 20;
        public int maxAmmo = 50;
        public int currentAmmo = 50;
        //ammo count text
        public TMP_Text ammoText;
        public TMP_Text ammoText2;
        public Camera fpsCam;
        public ParticleSystem muzzleFlash;

        // sound
        public AudioSource shootingAudio;
        public AudioSource reloadingAudio;

        private float nexTimetoFire = 0f;

        // Update is called once per frame
        void Update()
        {
            if(Input.GetButtonDown("Fire1") && Time.time >= nexTimetoFire)
            {
                nexTimetoFire = Time.time + 1f/fireRate;
                Shoot();
            }

            if(Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
            ammoText.text = "Current Clip: " + currentClip.ToString() + "/" + maxClip.ToString();
            ammoText2.text = "Current Ammo: " + currentAmmo.ToString() + "/" + maxAmmo.ToString();            
        }

        void Shoot()
        {
            if(currentClip > 0){
                muzzleFlash.Play();
                shootingAudio.Play();
                RaycastHit hit;
                currentClip -= 1;
                if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
                {
                    Debug.Log(hit.transform.name);

                    Target target = hit.transform.GetComponent<Target>();
                    if(target != null)
                    {
                        target.TakeDamage(damage);
                    }
                }
            }
        }

        public void Reload() {
            int reloadAmount = maxClip - currentClip;
            reloadingAudio.Play();
            reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
            currentClip += reloadAmount;
            currentAmmo -= reloadAmount;
        }

        public void AddAmmo(int ammoAmount) {
            currentAmmo += ammoAmount;
            if(currentAmmo > maxAmmo) 
            { 
                currentAmmo = maxAmmo;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Reload"))
            {
                Reload();
                Destroy(other.gameObject); // Destroy the object with "Reload" tag when player collides with it
            }
        }
    }
}