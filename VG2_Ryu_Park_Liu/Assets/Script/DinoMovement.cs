using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DinoGame
{
    public class DinoMovement : MonoBehaviour
    {
        public Transform target;
        NavMeshAgent navAgent;
        // Start is called before the first frame update
        void Awake()
        {

        }
        void Start()
        {
            navAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            if (target)
            {
                navAgent.SetDestination(target.position);
            }
        }
    }
}

