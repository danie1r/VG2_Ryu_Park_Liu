using System.Collections;
using System.Collections.Generic;
using DinoGame;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shots;
    private SimpleRayCast dino;

    Animator animator;

    void Start()
    {
        dino = shots.GetComponent<SimpleRayCast>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dino.death == true)
        {
            animator.SetBool("Death", true);
        }
    }
}
