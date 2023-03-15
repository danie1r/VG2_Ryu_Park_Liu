using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DinoGame
{
    public class OutOfBounds : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        private void OnCollisionEnter(Collision collision)
        {
            print("At the bottom");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

