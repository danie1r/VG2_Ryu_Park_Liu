using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DinoGame
{
    public class Key : MonoBehaviour
    {
        public int id;
        private string name = "Church Back Door";
        public TMP_Text keyList;

        void OnTriggerEnter(Collider other)
        {
            print("yesss");
            PlayerController targetPlayer = other.GetComponent<PlayerController>();
            if (targetPlayer != null)
            {
                keyList.text = keyList.text + "<br>" + name;
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

