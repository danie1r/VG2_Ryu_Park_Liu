using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMovement : MonoBehaviour
{
    public Transform target;
    public Rigidbody rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 to = target.position - transform.position;
        to = to.normalized;
        to = to * force;
        rb.AddForce(to);
    }
}
