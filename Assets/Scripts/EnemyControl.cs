using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
{
    public GameObject player;
    Transform target;
    public Bullet_Spawn spawnBullet;
    public Game_Control game_Control;
    public Text enemyHealth;


    void Start()
    {
        game_Control = FindObjectOfType<Game_Control>();
        player = GameObject.Find("Player");
        target = player.transform;

        Fire();
    }

    
    void Update()
    {
        //rotate towards player.
        var offset = 90f; 
        Vector2 direction = target.position - transform.position; //get the direction of the target.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;// to set angle wrt to position of target.
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));//rotate towards target with initial offset.

    }

    void Fire()
    {
        
        spawnBullet.Spawn();
        Invoke("Fire", 5f);// start firing every 5 seconds to the player
    }

    public void DestroEnemy()
    {
        
        Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "PlayerBullet")
        {

            game_Control.EnemyHealth();
            Destroy(other.gameObject);

        }

    }
}
