using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DinoGame
{
    public class Key : MonoBehaviour
    {
        public int id;

        void OnTriggerEnter(Collider other)
        {
            print("yesss");
            PlayerController targetPlayer = other.GetComponent<PlayerController>();
            if (targetPlayer != null)
            {

                targetPlayer.keyIdsObtained.Add(id);
                Destroy(gameObject);
            }
            //print(targetPlayer.keyIdsObtained);
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

