using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Pool : MonoBehaviour
{
    public static Bullet_Pool SharedInstance;
    public List<GameObject> pooledObjects;
    public List<GameObject> inActiveObjects;
    public GameObject objectToPool;
    public int amountToPool;
    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject obj;
        for (int i = 0; i < amountToPool; i++)
        {
            obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            
        }
        Player_Control.SharedInstance.Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject GetPooledObject()
    {
        
        for (int i = 0; i < amountToPool; i++)
        {

            if (!pooledObjects[i].activeInHierarchy)
            {
                
                return pooledObjects[i];
               

            }
        }

        return null;
    }
}
