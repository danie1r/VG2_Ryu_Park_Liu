using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update

    public int count = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Raptor"){
            count++;
        }

        if (collision.gameObject.name == "Pachycephalasaurus")
        {
            count++;
        }

        if (collision.gameObject.name == "Raptor(Clone)")
        {
            count++;
        }

        if (collision.gameObject.name == "Pachycephalasaurus(Clone)")
        {
            count++;
        }

        if (count >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
