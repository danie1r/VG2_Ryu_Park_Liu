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
        public float ammoCount = 20f;
        public TMP_Text ammoText;
        public Camera fpsCam;
        public ParticleSystem muzzleFlash;

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
                ammoCount = 20f;
            }
            ammoText.text = "Ammo Left: " + ammoCount.ToString() + "/20";
        }

        void Shoot()
        {
            if(ammoCount > 0){
                muzzleFlash.Play();
                RaycastHit hit;
                ammoCount -= 1;
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
    }
}