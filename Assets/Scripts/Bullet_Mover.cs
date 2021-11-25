using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Mover : MonoBehaviour
{
    public float bullet_Speed = -20f;
    public GameObject target;
    //public float angle = 0.5f;
    private Rigidbody2D rigidBody;
    void Start()
    {
        target = GameObject.Find("Player");
        rigidBody = GetComponent<Rigidbody2D>();
       
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = target.transform.position - transform.position;
        //rigidBody.AddForce(GameObject.Find("Player").transform.position * bullet_Speed);
        rigidBody.AddForce(direction* bullet_Speed);
    }
    
}
