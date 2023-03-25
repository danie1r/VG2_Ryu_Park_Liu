using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

namespace DinoGame{
    public class Target : MonoBehaviour
    {

        // public int dinoKillCount;
        // public TMP_Text killCount;

        public float health = 50f;

        

        public void TakeDamage(float amount)
        {
            health -= amount;
            if(health <= 0f)
            {
                Destroy(gameObject);
            }
        }

        // void OnDestroy()
        // {
        //     dinoKillCount += 100;
        //     killCount.text = "Kill Points: " + dinoKillCount.ToString();
        // }
    }
}