using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DinoGame
{
    public class InteractEnd : MonoBehaviour
    {
        public void Interact()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

