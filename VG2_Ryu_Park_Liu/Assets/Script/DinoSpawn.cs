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
        public GameObject pachy;

        private int dinoCount;
        private int pachyCount;
        public List<int[]> waveNumList = new List<int[]> { new int[] { 1, 8 }, new int[] { 4, 6 }, new int[] { 5, 6 } };
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
            pachy.GetComponent<DinoMovement>().target = FindObjectOfType<PlayerController>().transform;
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
            else if (index < waveNumList.Count)
            {
                dinoCount = waveNumList[index][0];
                pachyCount = waveNumList[index][1];
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
            while (dinoCount > 0 || pachyCount > 0)
            {
                //dinosaur.GetComponent<NavMeshAgent>().speed = speedList[index];
                if (dinoCount > 0){
                    int xPos = -47;
                    int yPos = 0;
                    int zPos = -17;
                    GameObject dinoCopy = Instantiate(dinosaur, new Vector3(xPos, yPos, zPos), Quaternion.identity);
                    dinoCopy.GetComponent<NavMeshAgent>().speed = speed;
                    dinoCount -= 1;
                }
                
                if (pachyCount > 0){
                    int xPos1 = -47;
                    int yPos1 = 0;
                    int zPos1 = -17;
                    GameObject pachyCopy = Instantiate(pachy, new Vector3(xPos1, yPos1, zPos1), Quaternion.identity);
                    pachyCopy.GetComponent<NavMeshAgent>().speed = speed;
                    pachyCount -= 1;
                }
                yield return new WaitForSeconds(0.7f);
                

            }
            speed += 2;

        }
    }
}

