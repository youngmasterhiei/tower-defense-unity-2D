using UnityEngine;
using System.Collections.Generic;

public class ObjectPooling : MonoBehaviour
{



    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {

    }



    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }


    public GameObject GetPooledObject()
    {
        // check existing pool for an inactive object
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        // pool is exhausted — create a new one and add it to the list
        GameObject newObject = Instantiate(objectToPool);
        newObject.SetActive(false);
        pooledObjects.Add(newObject);
        return newObject;
    }



}
