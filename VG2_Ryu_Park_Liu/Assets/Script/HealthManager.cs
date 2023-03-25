using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace DinoGame
{
    public class HealthManager : MonoBehaviour
    {
        public Image damageScreen;
        public Slider healthBar;
        public int life = 10;
        int maxLife;
        Color alphaColor;

        // Start is called before the first frame update
        void Start()
        {
            maxLife = life;
            healthBar.maxValue = maxLife;
            alphaColor = damageScreen.color;
        }

        // Update is called once per frame
        void Update()
        {
            healthBar.value = life;

        }

        public void TakeDamage()
        {
            if (life > 0)
            {
                life--;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                return;
            }
            alphaColor.a += .1f;
            damageScreen.color = alphaColor;
        }

        public void Heal()
        {
            if (life < maxLife)
            {
                life++;
            }

            alphaColor.a -= .1f;
            damageScreen.color = alphaColor;
        }
    }
}

