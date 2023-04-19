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
                life -= 2;
            }
            else
            {
                SceneManager.LoadScene(2);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                return;
            }
            alphaColor.a += .1f;
            damageScreen.color = alphaColor;
        }

        public void TakeDamage_Bald()
        {
            if (life > 0)
            {
                life--;
            }
            else
            {
                SceneManager.LoadScene(2);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                return;
            }
            alphaColor.a += .1f;
            damageScreen.color = alphaColor;
        }

        public void Heal(int amount)
        {
            if (life < maxLife)
            {
                life += amount;
                Debug.Log("Heal Working");
                alphaColor.a = 0f;
                damageScreen.color = alphaColor;
            }
        }
    }
}

