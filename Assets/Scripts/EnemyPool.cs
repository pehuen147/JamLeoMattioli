using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] List<GameObject> pooledObjects;
    [SerializeField] GameObject objectToPool;
    [SerializeField] int amountToPool;
    public static EnemyPool SharedInstance;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        SharedInstance = this;

        pooledObjects = new List<GameObject>();
        GameObject tmp;

        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool, this.transform);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public virtual GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                GameObject pObject = pooledObjects[i];
                pObject.SetActive(true);

                return pObject;
            }
        }

        GameObject tmp;
        tmp = Instantiate(objectToPool, this.transform);
        pooledObjects.Add(tmp);

        return tmp;
    }

    public bool CheckHorde()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].gameObject.activeInHierarchy)
            {
                return false;
            }
        }

        return true;
    }
}
