using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Scrolling : MonoBehaviour
{
    [SerializeField]
    private float bg_Speed = -.5f; //bg scrolling speed

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(0f, bg_Speed * Time.deltaTime, 0f);
        if (transform.position.y <= -25) // Check if bg has reached screen limits, then bring back to highest position.
        {
            transform.Translate(0f, 60f, 0f);
        }
    }
}
