using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public Game_Control game_Control;
    public List<GameObject> EnemyList = new List<GameObject>();
    void Start() // having enemies in a list to spawn them when needed.
    {
        Object[] subListPrefab = Resources.LoadAll("EnemyPrefabs", typeof(GameObject));
     // get all enemy prefabs in an array.
        foreach (GameObject x in subListPrefab)
        {
            GameObject lo = (GameObject)x;
            EnemyList.Add(lo);
        }

        SpawnEnemy();
        
    }

    public void SpawnEnemy() //spawn enemy at desired position as child.
    {
        GameObject myObj = Instantiate(EnemyList[0]) as GameObject;
        myObj.transform.parent = this.transform;
        myObj.transform.position = new Vector3(0, this.transform.position.y, 0);
        game_Control.enemyHealth = 100;
        game_Control.enemyHealthText.text = "Enemy Health : " + game_Control.enemyHealth.ToString();
    }
    
    void Update()
    {
        
    }
    public void manageList() //if list is not empty then, remove enemy1 from list and spawn bigger enemy..
    {

        if(EnemyList.Count > 1)
        {
            print(EnemyList.Count);
            EnemyList.RemoveAt(0);
            SpawnEnemy();
        }
        
        
        
    }
}
