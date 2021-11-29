using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    
    public GameObject powerShieldPrefab;
    public GameObject powerShootPrefab;
    private float spawnCycle = 12f;
    private float timeElapsed = 0;
    private bool shieldPowerup = true;
    void Update()
    {

        timeElapsed += Time.deltaTime;
        if (timeElapsed > spawnCycle)
        {
           
            if (shieldPowerup) //instantiate power shoot prefab
            {
                
                SpawnObstacle(powerShieldPrefab);
            }
            else //instantiate power shield prefab
            {
                SpawnObstacle(powerShootPrefab);              
            }

            timeElapsed -= spawnCycle;
            shieldPowerup = !shieldPowerup; //alternating between power ups.
        }
    }

    public void SpawnObstacle(GameObject prefab) //spawns powerups at from the set random positions.
    {
        
        GameObject temp;
        temp = Instantiate(prefab) as GameObject;
        
        Vector3 pos = temp.transform.position;
        temp.transform.position = new Vector3(Random.Range(-7, 7), 5f, pos.z);
    }
}
