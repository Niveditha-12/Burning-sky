using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Mover : MonoBehaviour
{
    public float bullet_Speed = -3f;
    private Rigidbody2D rigidBody;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); //Give bullet an initial downward velocity
        rigidBody.velocity = new Vector2(0, bullet_Speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
