using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.AI;

namespace DinoGame{
    public class Target : MonoBehaviour
    {

        // public int dinoKillCount;
        // public TMP_Text killCount;

        public float health = 50f;
        public Boolean isDead;
        Animator animator;


        private void Start()
        {
            animator = gameObject.GetComponent<Animator>();
            isDead = false;
        }

        private void Update()
        {
            //if (isDead)
            //{
            //    Destroy(gameObject);
            //}
        }


        public void TakeDamage(float amount)
        {
            animator.SetBool("Death", false);
            health -= amount;
            if(health <= 0f)
            {
                //animator.SetBool("Death", true);
                //yield return new WaitForSeconds(4f);
                //isDead = true;
                animator.SetBool("Death", true);
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
                Destroy(gameObject, 2);
            }
        }

        // void OnDestroy()
        // {
        //     dinoKillCount += 100;
        //     killCount.text = "Kill Points: " + dinoKillCount.ToString();
        // }
    }
}