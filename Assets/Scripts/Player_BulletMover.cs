using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BulletMover : MonoBehaviour
{
    [SerializeField]
    private float bullet_Speed = 3f;
    private Rigidbody2D rigidBody;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); //Give bullet an initial upward velocity
        rigidBody.velocity = new Vector2(0, bullet_Speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        
        if (other.gameObject.tag == "EnemyShip")
        {
            
            Destroy(this.gameObject);

        }

    }
}
