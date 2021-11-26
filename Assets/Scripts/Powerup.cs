using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    
    public GameObject powerShieldPrefab;
    public GameObject powerShootPrefab;
    [SerializeField]
    public float spawnCycle = 5f;
    private float timeElapsed = 0;
    private bool shieldPowerup = true;
    void Update()
    {

        timeElapsed += Time.deltaTime;
        if (timeElapsed > spawnCycle)
        {
            GameObject temp;
            if (shieldPowerup) //instantiate power shoot prefab
            {
                temp = Instantiate(powerShieldPrefab) as GameObject;
                Vector3 pos = temp.transform.position;
                temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
            }
            else //instantiate power shield prefab
            {
                temp = Instantiate(powerShootPrefab) as GameObject;
                Vector3 pos = temp.transform.position;
                temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
            }

            timeElapsed -= spawnCycle;
            shieldPowerup = !shieldPowerup; //alternating between power ups.
        }
    }
}
