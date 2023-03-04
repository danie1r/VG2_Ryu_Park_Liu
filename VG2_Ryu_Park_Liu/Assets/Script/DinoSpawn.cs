using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoSpawn : MonoBehaviour
{

    public GameObject dinosaur;
    public int xPos;
    public int yPos = 0;
    public int zPos;
    public int xPos1;
    public int zPos1;
    public int dinoCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DinoSpawnFunc());
    }

    IEnumerator DinoSpawnFunc()
    {
        while (dinoCount < 16)
        {
            xPos = Random.Range(-47, 8);
            zPos = Random.Range(-47, 68);
            xPos1 = Random.Range(19, 83);
            zPos1 = Random.Range(40, 90);
            Instantiate(dinosaur, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            //Instantiate(dinosaur, new Vector3(-45, yPos, zPos), Quaternion.identity);
            //Instantiate(dinosaur, new Vector3(93, yPos, zPos), Quaternion.identity);
            Instantiate(dinosaur, new Vector3(xPos1, yPos, zPos1), Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
            dinoCount += 2;
        }

    }
}
