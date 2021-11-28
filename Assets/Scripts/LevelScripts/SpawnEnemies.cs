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
        public float waveInterval = 2.0f;
        public float spawnInterval = 1f;
        public int enemiesPerWave = 2;
        public GameObject enemyType1;
        //Winscreen win;

        private void Awake()
        {
            SharedInstance = this;
        }
        void Start() // having enemies in a list to spawn them when needed.
        {

            AddEnemyToList();
            SpawnEnemy();
            StartCoroutine(SpawnEnemyWaves());

        }

        private void AddEnemyToList()
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
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                float waveType = Random.Range(0.0f, 10.0f);
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight + 2, 0));
                    Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight + 2, 0));
                    Vector3 spawnPosition = new Vector3(Random.Range(topLeft.x, topRight.x), topLeft.y, 0);
                    Quaternion spawnRotation = Quaternion.Euler(0, 0, 180);
                    if (waveType >= 5.0f)
                    {
                        GameObject bullet = EnemyPooler.SharedInstance.GetPooledObject();
                        if (bullet != null)
                        {
                            bullet.transform.position = bullet.transform.position = new Vector3(0, 1.2f, 0);
                            bullet.transform.rotation = this.transform.rotation;
                            bullet.SetActive(true);
                        }
                    }

                    yield return new WaitForSeconds(spawnInterval);
                }
                yield return new WaitForSeconds(waveInterval);
            }
        }

        void Update()
        {

        }
        public void manageList() //if list is not empty then, remove enemy1 from list and spawn bigger enemy..
        {

            if (EnemyList.Count > 1)
            {

                EnemyList.RemoveAt(0);
                SpawnEnemy();
            }
            else // when player destroys all enemies load winning screen
            {

                Time.timeScale = 0;
                Winscreen.open();
            EnemyList.Clear();
                AddEnemyToList();
            }



        }
    }

