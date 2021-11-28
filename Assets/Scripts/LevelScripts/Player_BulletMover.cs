﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BulletMover : MonoBehaviour
{
    [SerializeField]
    private float bullet_Speed = 10f;
    private Rigidbody2D rigidBody;
    public Game_Control game_Control;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); 
        rigidBody.velocity = new Vector2(0, bullet_Speed);//Give bullet an initial upward velocity
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(0, bullet_Speed);
    }
   
}