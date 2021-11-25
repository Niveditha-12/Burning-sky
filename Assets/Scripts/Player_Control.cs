﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float playerSpeed = 10f;
    public Game_Control gameController;
    public GameObject bulletPrefab;
    public float reloadTime = 0.2f; // Player can fire a bullet every half second
    private float elapsedTime = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        PlayerMovement();
        if (Input.GetButtonDown("Jump") && elapsedTime > reloadTime)
        {

            Vector3 spawnPos = transform.position;
            spawnPos += new Vector3(0, 1.2f, 0);// Instantiate the bullet 1.2 units in front of the player
            Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
            elapsedTime = 0f; // Reset bullet firing timer
        }
    }
    void PlayerMovement()
    {
        PlayerBoundary();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * playerSpeed * Time.deltaTime);
    }
    void PlayerBoundary()
    {
        float xClamp = Mathf.Clamp(transform.position.x, -7, 7);
        float yClamp = Mathf.Clamp(transform.position.y, -3, 3);
        transform.position = new Vector3(xClamp, yClamp, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
            gameController.HealthScore();
        }
        
    }
}