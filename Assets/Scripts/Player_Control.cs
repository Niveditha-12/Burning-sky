using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public static Player_Control SharedInstance;
    public float playerSpeed = 10f;
    public Game_Control gameController;
    public GameObject bulletPrefab;
    private float elapsedTime = 0;
    public bool powerShield = false;
    bool powerShoot = false;
    public GameObject shield;
    private float bullet_Speed = 3f;

    private void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        

        
        PlayerMovement();
        
        
    }
    public void Spawn()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject bullet = Bullet_Pool.SharedInstance.GetPooledObject();

            if (bullet != null)
            {
                float j = -1f + i;
                Vector3 spawnPos = transform.position;
                spawnPos += new Vector3(j, 1.2f, 0);
                bullet.transform.position = spawnPos;
                bullet.SetActive(true);
                Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();
                rigidBody.velocity = new Vector2(0, bullet_Speed);
            }

            
        }
            
        
        Invoke("Spawn", .5f);
        
        
    }
    
    void PlayerMovement() //move the player with arrow keys.
    {
        PlayerBoundary(); 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * playerSpeed * Time.deltaTime);
    }
    void PlayerBoundary() //restrict player movement out of boundary
    {
        float xClamp = Mathf.Clamp(transform.position.x, -7, 7);
        float yClamp = Mathf.Clamp(transform.position.y, -3, 3);
        transform.position = new Vector3(xClamp, yClamp, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "EnemyBullet") //if hit by enemy and there is no shield, decrease health 
        {
            Destroy(other.gameObject);
            if (powerShield == false)
            {
                gameController.HealthScore();
            }
           
        }
        if (other.gameObject.tag == "PowerShield") // if hit by powerup, switch on the shield.
        {
            Destroy(other.gameObject);
            PowerupShieldCollected();
        }
        if (other.gameObject.tag == "PowerShoot") // if hit by powershoot, call spray shoot function
        {
            Destroy(other.gameObject);
            PowerupShootCollected();
        }
    }
    public void PowerupShieldCollected() // when powerup is collected, play particle system (shield) for 4 seconds and stop.
    {
        powerShield = true;
        shield.SetActive(true);
        StartCoroutine(PowerUpTime());
        IEnumerator PowerUpTime()
        {

            yield return new WaitForSeconds(10); // Time to continously fire bullets.
            shield.SetActive(false);
            powerShield = false;
        }


    }
    public void PowerupShootCollected() // when powerup is collected, play particle system (shield) for 4 seconds and stop.
    {

         powerShoot = true;
        StartCoroutine(PowerUpTime());
        IEnumerator PowerUpTime()
        {

            yield return new WaitForSeconds(10); // Time to continously fire bullets.
            shield.SetActive(false);
            powerShoot = false;
        }


    }
}
