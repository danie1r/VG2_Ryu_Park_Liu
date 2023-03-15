using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DinoGame
{
    public class DinoSpawn : MonoBehaviour
    {
        public TMP_Text waveText;
        public GameObject dinosaur;
        public int xPos;
        public int yPos = 0;
        public int zPos;
        public int xPos1;
        public int zPos1;
        public int dinoCount;
        public int[] waveNumList = { 1, 2, 3, 4 };
        public int index = 0;
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
            if (index < waveNumList.Length)
            {
                dinoCount = waveNumList[index];

                StartCoroutine(DinoSpawnFunc());
                index++;
            }
            else
            {
                waveText.text = "Wave Complete!";
            }
        }
        void Update()
        {
            waveText.text = "Wave Level: " + (index).ToString();
        }
        IEnumerator DinoSpawnFunc()
        {
            while (dinoCount > 0)
            {
                xPos = Random.Range(-47, 8);
                zPos = Random.Range(-47, 68);
                xPos1 = Random.Range(19, 83);
                zPos1 = Random.Range(40, 90);
                Instantiate(dinosaur, new Vector3(xPos, yPos, zPos), Quaternion.identity);
                //Instantiate(dinosaur, new Vector3(-45, yPos, zPos), Quaternion.identity);
                //Instantiate(dinosaur, new Vector3(93, yPos, zPos), Quaternion.identity);
                //Instantiate(dinosaur, new Vector3(xPos1, yPos, zPos1), Quaternion.identity);
                yield return new WaitForSeconds(0.3f);
                dinoCount -= 1;
            }

        }
    }
}

