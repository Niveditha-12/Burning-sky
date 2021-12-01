using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level5Enemy : MonoBehaviour
{
    Transform target;
    public GameObject player;
    public Bullet_Spawn spawnBullet;
    [SerializeField]
    float health=1f;
    public Image img;
    
    private void Start()
    {
        health = 1;
        img.fillAmount = 1;
        Fire();
        target = player.transform;
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
        Invoke("Fire", 2f);// start firing every 5 seconds to the player
    }
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "PlayerBullet")
        {

            health += -.05f;
            print(health);
            img.fillAmount = health;
            if (health < 0)
            {
                Destroy(this.gameObject);
            }
            
            other.gameObject.SetActive(false);

        }

    }

}
