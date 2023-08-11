using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[Serializable]
public class ObjectPoolEntry
{
    public GameObject prefab;
    public int poolSize;
}

public class ObjectPool : MonoBehaviour, IObjectPool
{
    [SerializeField]
    private List<ObjectPoolEntry> poolEntries = new List<ObjectPoolEntry>();
    private Dictionary<string, Queue<GameObject>> objectPool = new Dictionary<string, Queue<GameObject>>();
    private DiContainer container;

    [Inject]
    public void Construct(DiContainer container)
    {
        this.container = container;
    }

    private void Start()
    {
        // InitializeObjectPool();
        InitializeObjectPool();
        foreach (var kvp in objectPool)
        {
            Debug.Log($"Key: {kvp.Key}, Value: {kvp.Value.ToString()}");
        }
    }

    private void InitializeObjectPool()
    {
        foreach (var entry in poolEntries)
        {
            if (entry.prefab == null || entry.poolSize <= 0)
            {
                Debug.Log("Invalid prefab or pool size in ObjectPoolEntry.");
                continue;
            }

            if (objectPool.ContainsKey(entry.prefab.name))
            {
                Debug.Log("Prefab is already in the pool.");
                continue;
            }

            objectPool[entry.prefab.name] = new Queue<GameObject>();

            for (int i = 0; i < entry.poolSize; i++)
            {
               
                CreateObjectInPool(entry.prefab);
            }
        }
    }

    private GameObject CreateObjectInPool(GameObject prefab)
    {
        GameObject obj = container.InstantiatePrefab(prefab, transform.position, Quaternion.identity, null);
        obj.SetActive(false);
        obj.transform.parent = transform;
        objectPool[prefab.name].Enqueue(obj);
        obj.name = prefab.name;
        return obj;
    }

    public GameObject GetObjectFromPool(GameObject prefab)
    {
        if (objectPool.ContainsKey(prefab.name) && objectPool[prefab.name].Count > 0)
        {
            GameObject pooledObject = objectPool[prefab.name].Dequeue();
            pooledObject.SetActive(true);
            return pooledObject;
        }
        else
        {
            
            CreateObjectInPool(prefab);
            GameObject pooledObject = objectPool[prefab.name].Dequeue();
            pooledObject.SetActive(true);
            return pooledObject;
        }
    }

    public void ReturnObjectToPool(GameObject prefab, GameObject obj)
    {
        if (objectPool.ContainsKey(prefab.name))
        {
            obj.SetActive(false);
            objectPool[prefab.name].Enqueue(obj);
        }
        else
        {
            CheckObjectPoolContent();
            Debug.LogError("Invalid prefab. Object cannot be returned to the pool.");
        }
    }

    public void ExpandPool(GameObject prefab, int amount)
    {
        if (amount <= 0)
        {
            Debug.LogError("Invalid amount. Pool cannot be expanded.");
            return;
        }

        if (objectPool.ContainsKey(prefab.name))
        {
            for (int i = 0; i < amount; i++)
            {
                CreateObjectInPool(prefab);
            }
        }
        else
        {
            Debug.LogError("Invalid prefab. Pool cannot be expanded.");
        }
    }
    private void CheckObjectPoolContent()
    {
        foreach (var entry in objectPool)
        {
            Debug.Log("Prefab: " + entry.Key + ", Object Count: " + entry.Value.Count);
        }
    }
   
}