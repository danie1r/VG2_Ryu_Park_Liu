using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoSpawn : MonoBehaviour
{

    public GameObject dinosaur;
    public int xPos;
    public int yPos = 1;
    public int zPos;
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
            xPos = Random.Range(-45, 95);
            zPos = Random.Range(-48, 98);
            Instantiate(dinosaur, new Vector3(xPos, yPos, 98), Quaternion.identity);
            Instantiate(dinosaur, new Vector3(-45, yPos, zPos), Quaternion.identity);
            Instantiate(dinosaur, new Vector3(93, yPos, zPos), Quaternion.identity);
            Instantiate(dinosaur, new Vector3(xPos, yPos, -46), Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
            dinoCount += 4;
        }

    }
}
