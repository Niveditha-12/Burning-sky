using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Spawn : MonoBehaviour   // bullets from the main enemy
{
    
    public GameObject bulletPrefab;
    private float elapsedTime = 0;
    
    //public float reloadTime = 10f;
    

    void Start()
    {
        
    }

    public void Spawn()
    {
        elapsedTime = 0;
        Bullet();
        StartCoroutine(FireTime());
        IEnumerator FireTime()
        {
            
            yield return new WaitForSeconds(1); // Time to continously fire bullets.
            elapsedTime = 2;
        }
        

    }

      void Bullet()
      {

          Vector3 spawnPos = this.transform.parent.position + new Vector3(0, 0, 0);
        Instantiate(bulletPrefab, spawnPos, transform.parent.rotation);
          if (elapsedTime < 2)
          {
              Invoke("Bullet", .2f);// spawn bullets every .2s for 1 second.
          }

      }
    
   
}
