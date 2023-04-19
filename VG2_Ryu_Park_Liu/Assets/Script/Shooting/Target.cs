using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.AI;

using UnityEngine;
using UnityEngine.AI;

namespace DinoGame
{
    public class Target : MonoBehaviour
    {
        public float health = 50f;
        Animator animator;
        public PlayerController player;
        public AudioSource deathSound; // Add an AudioSource for the death sound

        private void Start()
        {
            animator = gameObject.GetComponent<Animator>();
            player = FindObjectOfType<PlayerController>();
            deathSound = GetComponent<AudioSource>(); // Get the AudioSource component from the GameObject
        }

        private void Update()
        {
        }

        public void TakeDamage(float amount)
        {
            animator.SetBool("Death", false);
            health -= amount;
            if (health <= 0f)
            {
                animator.SetBool("Death", true);
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
                gameObject.GetComponent<Rigidbody>().detectCollisions = false;
                player.dinoKillCount += 100;
                gameObject.GetComponent<DinoMovement>().target = null;
                Destroy(gameObject, 8);

                // Play the death sound
                if (deathSound != null) // Make sure the AudioSource component is not null
                {
                    deathSound.Play(); // Play the death sound
                }
            }
        }
    }
}

        // void OnDestroy()
        // {
        //     dinoKillCount += 100;
        //     killCount.text = "Kill Points: " + dinoKillCount.ToString();
        // }