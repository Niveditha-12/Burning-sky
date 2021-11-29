using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    public static EnemyPooler SharedInstance;
    public List<GameObject> pooledObjects;
   
    public GameObject objectToPool;
    public int amountToPool =3;
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

    public GameObject GetPooledObject()
    {
        if(Game_Control.SharedInstance.Level == 3) //on level 4, increase the number of obstacles.
        {
            amountToPool = 5;
        }
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





