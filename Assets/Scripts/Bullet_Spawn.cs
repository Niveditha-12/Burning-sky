using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Spawn : MonoBehaviour
{
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;
    public GameObject bulletPrefab;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        // spawn bullet from ship's position. 
        Vector3 spawnPos = this.transform.parent.position + new Vector3(0, 0, 0);
        Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
    void Update()
    {
       
    }
}
