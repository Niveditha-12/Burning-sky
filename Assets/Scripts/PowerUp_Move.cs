using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Move : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float powerUP_Speed = -3f;
    private Rigidbody2D rigidBody;
    

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(0, powerUP_Speed);//Give bullet an initial upward velocity
    }
}
