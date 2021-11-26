using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    
    public GameObject powerupPrefab;
    public float spawnCycle = 0.5f;
    private float timeElapsed = 0;
    private bool spawnPowerup = true;
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > spawnCycle)
        {
            GameObject temp;
            if (spawnPowerup)
            {
                temp = Instantiate(powerupPrefab) as GameObject;
                Vector3 pos = temp.transform.position;
                temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
            }
            
            timeElapsed -= spawnCycle;
            spawnPowerup = !spawnPowerup;
        }
    }
}
