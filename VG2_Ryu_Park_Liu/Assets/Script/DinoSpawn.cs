using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

namespace DinoGame
{
    public class DinoSpawn : MonoBehaviour
    {
        public TMP_Text waveText;
        public GameObject dinosaur;
        public int dinoCount;
        public int[] waveNumList = { 10, 15, 20, 30 };
        public int speed = 5;
        public int index = 0;
        public bool timerRunning = true;
        float timeRemain = 5;
        void Awake()
        {

        }
        // Start is called before the first frame update
        void Start()
        {
            dinosaur.GetComponent<DinoMovement>().target = FindObjectOfType<PlayerController>().transform;

        }

        public void SpawnAgain()
        {

            if (timerRunning)
            {
                if (timeRemain > 0)
                {
                    timeRemain -= Time.deltaTime;
                    waveText.text = "Time until next wave: " + Mathf.Round(timeRemain).ToString();
                }
                else
                {
                    timerRunning = false;
                    timeRemain = 10;
                }

            }
            else if (index < waveNumList.Length)
            {
                dinoCount = waveNumList[index];
                waveText.text = "Wave Level: " + (index + 1).ToString();
                StartCoroutine(DinoSpawnFunc());
                index++;
                timerRunning = true;
            }
            else
            {
                waveText.text = "Wave Complete! Game Clear";
            }
        }
       
        IEnumerator DinoSpawnFunc()
        {
            while (dinoCount > 0)
            {
                //dinosaur.GetComponent<NavMeshAgent>().speed = speedList[index];
                int xPos = -47;
                int yPos = 0;
                int zPos = -17;
                int xPos1 = -47;
                int yPos1 = 0;
                int zPos1 = -17;
                GameObject dinoCopy = Instantiate(dinosaur, new Vector3(xPos, yPos, zPos), Quaternion.identity);
                GameObject dinoCopy1 = Instantiate(dinosaur, new Vector3(xPos1, yPos1, zPos1), Quaternion.identity);
                dinoCopy.GetComponent<NavMeshAgent>().speed = speed;
                dinoCopy1.GetComponent<NavMeshAgent>().speed = speed;
                yield return new WaitForSeconds(0.7f);
                dinoCount -= 2;

            }
            speed += 2;

        }
    }
}

