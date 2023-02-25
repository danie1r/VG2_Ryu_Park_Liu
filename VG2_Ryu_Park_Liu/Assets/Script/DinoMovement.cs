using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMovement : MonoBehaviour
{
    public Transform target;
    public Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 to = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        rb.MovePosition(to);
    }
}
