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
    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject GetPooledObject()
    {
        inActiveObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {

            if (!pooledObjects[i].activeInHierarchy)
            {
                //inActiveObjects.Add(pooledObjects[i]);
                return pooledObjects[i];
                //return inActiveObjects;

            }
        }

        return null;
    }
}
