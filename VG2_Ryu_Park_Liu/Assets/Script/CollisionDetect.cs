using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DinoGame
{

    public class CollisionDetect : MonoBehaviour
    {
        public GameObject health;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                health.GetComponent<HealthManager>().TakeDamage();
            }
        }
    }
}

