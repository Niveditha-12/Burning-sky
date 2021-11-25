using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Spawn : MonoBehaviour
{
    public float minSpawnDelay = .5f;
    public float maxSpawnDelay = 1f;
    public GameObject bulletPrefab;
    private float elapsedTime = 0;
    private float elapsedTime1 = 0;
    public float reloadTime = 10f;

    void Start()
    {
        //Spawn();
    }

    public void Spawn()
    {
        elapsedTime = 0;
        Bullet();
        StartCoroutine(Example());
        IEnumerator Example()
        {
            
            yield return new WaitForSeconds(1);
            elapsedTime = 2;
        }

        
    }

    void Bullet()
    {
         
        
        Vector3 spawnPos = this.transform.parent.position + new Vector3(0, 0, 0);
        Instantiate(bulletPrefab, spawnPos, transform.parent.rotation);
        if (elapsedTime < 2)
        {
            Invoke("Bullet", .2f);
        }
        
    }
    void Update()
    {
       
    }
}
