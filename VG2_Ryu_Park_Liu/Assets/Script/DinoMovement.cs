using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DinoMovement : MonoBehaviour
{
    public Transform target;
    NavMeshAgent navAgent;
    private float health;
    // Start is called before the first frame update
    void Awake()
    {
        health = 100;
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
    public void TakeDamage()
    {
        health -= 40;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}
