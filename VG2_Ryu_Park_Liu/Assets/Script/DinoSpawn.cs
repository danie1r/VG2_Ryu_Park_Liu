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
        public GameObject tRex;
        private int dinoCount;
        private int pachyCount;
        private int tRexCount;
        public List<int[]> waveNumList = new List<int[]> { new int[] { 3, 5, 0 }, new int[] { 5, 4,0 }, new int[] { 5, 6,1 } };
        public int speed = 5;
        public int index = 0;
        public bool timerRunning = true;
        private bool gameOver = false;
        float timeRemain = 5;
        private int[] xPosArr = {-47, -25, 47};
        private int[] zPosArr = {-17, 57, 83};

        void Awake()
        {
            dinosaur.GetComponent<DinoMovement>().target = FindObjectOfType<PlayerController>().transform;
            pachy.GetComponent<DinoMovement>().target = FindObjectOfType<PlayerController>().transform;
            tRex.GetComponent<DinoMovement>().target = FindObjectOfType<PlayerController>().transform;
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        public void SpawnAgain()
        {

            if (timerRunning && !gameOver)
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
            else if (index < waveNumList.Count && !gameOver)
            {
                dinoCount = waveNumList[index][0];
                pachyCount = waveNumList[index][1];
                tRexCount = waveNumList[index][2];
                waveText.text = "Wave Level: " + (index + 1).ToString();
                StartCoroutine(DinoSpawnFunc());
                index++;
                if (index == waveNumList.Count){
                    gameOver = true;
                }
                timerRunning = true;
            }
            else
            {
                waveText.text = "Wave Complete! Game Clear";
            }
        }
       
        IEnumerator DinoSpawnFunc()
        {
            while (dinoCount > 0 || pachyCount > 0 || tRexCount > 0)
            {
                //dinosaur.GetComponent<NavMeshAgent>().speed = speedList[index];
                
                int index = Mathf.RoundToInt(Random.Range(0,2));
                int xPos = xPosArr[index];
                int zPos = zPosArr[index];
                int yPos = 0;
                if (dinoCount > 0){
                    
                    GameObject dinoCopy = Instantiate(dinosaur, new Vector3(xPos, yPos, zPos), Quaternion.identity);
                    dinoCopy.GetComponent<NavMeshAgent>().speed = speed;
                    dinoCount -= 1;
                }
                
                if (pachyCount > 0){
                    
                    GameObject pachyCopy = Instantiate(pachy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
                    pachyCopy.GetComponent<NavMeshAgent>().speed = speed;
                    pachyCount -= 1;
                }

                if (tRexCount > 0)
                {
                    GameObject tRexCopy = Instantiate(tRex, new Vector3(xPos, yPos, zPos), Quaternion.identity);
                    tRexCopy.GetComponent<NavMeshAgent>().speed = speed;
                    tRexCount -= 1;
                }
                yield return new WaitForSeconds(1f);
                

            }
            speed += 2;

        }
    }
}

