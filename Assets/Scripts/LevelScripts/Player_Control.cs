using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public static Player_Control SharedInstance;
    public float playerSpeed = 10f;
    public Game_Control gameController;
    public GameObject bulletPrefab;
    private AudioSource muAudio;
    public bool powerShield = false;
    bool powerShoot = false;
    public GameObject shield;
    public int no_of_bullets;
    private float bullet_Speed = 3f;
    Vector3 spawnPos;

    private void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        muAudio = GetComponent<AudioSource>();
        gameController.LoadPreferences();
    }

    // Update is called once per frame
    void Update()
    {             
        PlayerMovement();
        spawnPos = transform.position;
        spawnPos += new Vector3(0, 1.2f, 0);
    }
    public void Spawn()
    {
        Game_Control.SharedInstance.audioSource.Play();
        if (!powerShoot)
        {
            no_of_bullets = 3;
        }
        if (powerShoot)
        {
            no_of_bullets = 5;
        }
        int k = 0;
        for (int i = 0; i < no_of_bullets; i++)
            {
            
            GameObject bullet = Bullet_Pool.SharedInstance.GetPooledObject();
            
            if (bullet != null) //fire few bullets at a time. 
            {      
                                     
                    int angle = -15 + k;
                    k += 15;                   
                    bullet.transform.rotation = Quaternion.Euler(Vector3.forward * (angle));                                                                         
                    bullet.SetActive(true);
                
                bullet.transform.position = spawnPos;
            }

            
        }
         
        Invoke("Spawn", .8f);



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
        muAudio.Play();
        powerShield = true;
        shield.SetActive(true);
        StartCoroutine(PowerUpTime());
        IEnumerator PowerUpTime()
        {

            yield return new WaitForSeconds(8); // Time for booster
            shield.SetActive(false);
            powerShield = false;
        }


    }
    public void PowerupShootCollected() // when powerup is collected, play particle system (shield) for 8 seconds and stop.
    {
        muAudio.Play();
         powerShoot = true;
        StartCoroutine(PowerUpTime());
        IEnumerator PowerUpTime()
        {

            yield return new WaitForSeconds(8); // Time for booster
            shield.SetActive(false);
            powerShoot = false;
        }


    }
}
