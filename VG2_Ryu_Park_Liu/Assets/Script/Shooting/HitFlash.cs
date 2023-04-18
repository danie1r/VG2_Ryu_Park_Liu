using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitFlash : MonoBehaviour
{

    MeshRenderer meshRenderer;
    Color originalColor;
    float flashTime = .15f;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            FlashStart();
        }
    }

    void FlashStart()
    {
        meshRenderer.material.color = Color.red;
        Invoke("FlashStop", flashTime);
    }

    void FlashStop()
    {
        meshRenderer.material.color = originalColor;
    }
}
