using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if ( (other.gameObject.tag == "PlayerBullet") || (other.gameObject.tag == "Obstacle"))             
        {          
            other.gameObject.SetActive(false);
        }

        if ((other.gameObject.tag == "EnemyBullet") || (other.gameObject.tag == "PowerShoot") || (other.gameObject.tag == "PowerShield") )
        {

            Destroy(other.gameObject);

        }
       
    }
}
