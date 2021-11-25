using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameObject player;
    Transform target;
    int speed = 1;
    public Bullet_Spawn spawnBullet;
    
    

    
    void Start()
    {
        target = player.transform;

        Fire();
    }

    
    void Update()
    {

        var offset = 90f; // to set initial rotation to 0
        Vector2 direction = target.position - transform.position; //get the direction of the target.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;// to set angle wrt to position of target.
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));//rotate towards target with initial offset.

    }

    void Fire()
    {
        
        spawnBullet.Spawn();
        Invoke("Fire", 3f);
    }

    public void NewEnemy()
    {

    }
}
