using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DinoGame{
    public class Gun : MonoBehaviour
    {
        public float damage = 10f;
        public float range = 100f;
        public Camera fpsCam;
        public ParticleSystem muzzleFlash;
        public GameObject impactEffect;

        public int magSize = 30;

        public int bulletsLeft;

        public int bulletsUsed;


        // Update is called once per frame
        void Update()
        {
            Keyboard keyboardInput = Keyboard.current;
            Mouse mouseInput = Mouse.current;

            if(mouseInput.leftButton.wasPressedThisFrame)
            {
                Shoot();
            }
        }

        void Shoot()
        {
            muzzleFlash.Play();
            RaycastHit hit;
            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

               Target target =  hit.transform.GetComponent<Target>();
               if(target != null)
               {
                target.TakeDamage(damage);
               }

               Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }
}