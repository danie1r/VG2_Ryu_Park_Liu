using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZoneScript : MonoBehaviour
{
    float timeRemain = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemain > 0)
        {
            timeRemain -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
