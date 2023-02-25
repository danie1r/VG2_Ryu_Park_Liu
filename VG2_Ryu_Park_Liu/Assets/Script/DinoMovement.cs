using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMovement : MonoBehaviour
{
    public Transform target;
    public Rigidbody rb;
    public float speed;
    private float health;
    // Start is called before the first frame update
    void Awake()
    {
        health = 100;
    }
    public void TakeDamage()
    {
        health -= 40;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 to = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        rb.MovePosition(to);
    }
}
