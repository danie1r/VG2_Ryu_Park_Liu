// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ProjectileGunTutorial : MonoBehaviour
// {
//     // bullet prefab
//     public GameObject bullet;

//     // bullet force
//     public float shootForce, upwardForce;

//     // gun statistics
//     public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
//     public int magainzeSize, bulletsPerTap;
//     public bool allowButtonHold;

//     int bulletsLeft, bulletsShot;

//     // bools
//     bool shooting, readyToShoot, reloading;

//     // references
//     public Camera fpsCam;
//     public Transform attackPoint;

//     public bool allowInvoke = true;

//     private void Awake()
//     {
//         bulletsLeft = magainzeSize;
//         readyToShoot = true;
//     }

//     private void Update()
//     {
//         MyInput();

//     }

//     private void MyInput(){
//         if(allowButtonHold) shooting = Input.GetButton(KeyCode.Mouse0);
//         else shooting = Input.GetButtonDown(KeyCode.Mouse0);

//         // for reloading
//         if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < magainzeSize && !reloading)
//         {
//             Reload();
//         }

//         // for shooting
//         if(readyToShoot && shooting && !reloading && bulletsLeft > 0)
//         {
//             bulletsShot = bulletsPerTap;
//             Shoot();
//         }
//     }

//     private void Shoot(){
//         readyToShoot = false;

//         Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
//         RaycastHit hit;

//         Vector3 targetPoint;
//         if(Physics.Raycast(ray, out hit))
//         {
//             targetPoint = hit.point;
//         }
//         else
//         {
//             targetPoint = ray.GetPoint(100);
//         }

//         // Calculate direction from the muzzle to the target we want
//         Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

//         float x = Random.Range(-spread, spread);
//         float y = Random.Range(-spread, spread);

//         // Calculate the direction with spread
//         Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

//         // Instantiate bullet
//         GameObject uccrentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

//         currentBullet.transform.forward = directionWithoutSpread.normalized;

//         // Bullet force
//         currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);

//         // bullet countdown
//         bulletsLeft--;
//         bulletsShot++;

//         if(allowInvoke)
//         {
//             Invoke("ResetShot", timeBetweenShots);
//             allowInvoke = false;
//         }
//     }

//     private void ResetShot()
//     {
//         readyToShoot = true;
//         allowInvoke = true;
//     }

//     private void Reload()
//     {
//         reloading = true;
//         Invoke("ReloadFinished", reloadTime);
//     }

//     private void ReloadFinished()
//     {
//         bulletsLeft = magainzeSize;
//         reloading = false;
//     }
// }
