using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Mover : MonoBehaviour
{
    public float bullet_Speed = -20f;
    public GameObject target;
    private Rigidbody2D rigidBody;
    void Start()
    {
        target = GameObject.Find("Player");
        rigidBody = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    { 
        //fire in the direction of player
        Vector2 direction = target.transform.position - transform.position;
        rigidBody.AddForce(direction* bullet_Speed);
    }
    
}
