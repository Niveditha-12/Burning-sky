using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelManagement;

public class SpawnEnemies : MonoBehaviour
{
    public static SpawnEnemies SharedInstance;
    public Game_Control game_Control;
    public List<GameObject> EnemyList = new List<GameObject>();
    public float startWait = 1.0f;
    public float waveInterval = 1.0f;
    public float spawnInterval = 1f;
    private int enemiesPerWave = 3;
    public GameObject enemyType1;
    AudioSource myAud;

    private void Awake()
    {
        SharedInstance = this;
    }
    void Start() // having enemies in a list to spawn them when needed.
    {
        myAud = GetComponent<AudioSource>();
        AddEnemyToList();
        SpawnEnemy();
        StartCoroutine(SpawnEnemyWaves());

    }

    public void AddEnemyToList()
    {
        Object[] subListPrefab = Resources.LoadAll("EnemyPrefabs", typeof(GameObject));
        // get all enemy prefabs in an array.
        foreach (GameObject x in subListPrefab)
        {
            GameObject lo = (GameObject)x;
            EnemyList.Add(lo);
        }
    }
    public void SpawnEnemy() //spawn enemy at desired position as child.
    {

        GameObject myObj = Instantiate(EnemyList[0]) as GameObject;
        myObj.transform.parent = this.transform;
        myObj.transform.position = new Vector3(12f, 4.4f, 0);
        game_Control.enemyHealth = 100;
        game_Control.enemyHealthText.text = "Enemy Health : " + game_Control.enemyHealth.ToString();
    }

    IEnumerator SpawnEnemyWaves()// spawn obstacles.
    {

        if(MenuManager.Instance.LevelNum >2)
        {
            enemiesPerWave = 6;
        }
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            float waveType = Random.Range(0.0f, 10.0f);
            for (int i = 0; i < enemiesPerWave; i++) //start spawning them from random positions within screen.
            {
                
                Quaternion spawnRotation = Quaternion.Euler(0, 0, 180);
                if (waveType >= 5.0f) //spawn at random intervals.
                {
                    GameObject bullet = EnemyPooler.SharedInstance.GetPooledObject();
                    if (bullet != null)
                    {
                        int rRandomPosx = Random.Range(5, -5);
                        bullet.transform.position = bullet.transform.position = new Vector3(rRandomPosx, 8f, 0);

                        bullet.transform.rotation = this.transform.rotation;
                        bullet.SetActive(true);

                    }
                }

                yield return new WaitForSeconds(spawnInterval);//spawn each obstacle each second.
            }
            yield return new WaitForSeconds(waveInterval); //repeat the pattern every 5 seconds.
        }
    }

    void Update()
    {
        if (Game_Control.SharedInstance.Level > 2)
        {
            enemiesPerWave = 5;
        }
    }
    public void manageList() //if list is not empty then, remove enemy1 from list and spawn bigger enemy..
    {

        if (EnemyList.Count > 1)
        {
            EnemyList.RemoveAt(0);
            SpawnEnemy();
            
            

        }
        else // when player destroys all enemies load winning screen and add enemies to the list for next level.
        {
            //myAud.Stop();
            Game_Control.SharedInstance.audioSource.Stop();
            Time.timeScale = 0;
            EnemyList.Clear();
           
        }



    }
    

}

