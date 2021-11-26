using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float playerSpeed = 10f;
    public Game_Control gameController;
    public GameObject bulletPrefab;
    private float elapsedTime = 0;
    bool powerShield = false;
    bool powerShoot = false;
    public GameObject shield;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        PlayerMovement();
        if (Input.GetButtonDown("Jump") ) 
        {
            if(!powerShoot)
            {
                Vector3 spawnPos = transform.position;
                spawnPos += new Vector3(0, 1.2f, 0);// Instantiate the bullet 1.2 units in front of the player
                Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
            }
            
            if(powerShoot)// if power shoot is activated, then start spray shoot.
            {
                
                for(int i = 0; i < 5; i++)
                {
                    float j = -2f +i;
                    Vector3 spawnPos = transform.position;
                    spawnPos += new Vector3(j, 1.2f, 0);// Instantiate the bullet 1.2 units in front of the player
                    Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
                }
                
                
            }
        }
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
