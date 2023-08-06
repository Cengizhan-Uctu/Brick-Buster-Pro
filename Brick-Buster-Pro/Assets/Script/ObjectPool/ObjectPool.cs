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
    private Dictionary<GameObject, Queue<GameObject>> objectPool = new Dictionary<GameObject, Queue<GameObject>>();
    private DiContainer container;

    [Inject]
    public void Construct(DiContainer container)
    {
        this.container = container;
    }

    private void Start()
    {
        InitializeObjectPool();
    }

    private void InitializeObjectPool()
    {
        foreach (var entry in poolEntries)
        {
            if (entry.prefab == null || entry.poolSize <= 0)
            {
                Debug.LogError("Invalid prefab or pool size in ObjectPoolEntry.");
                continue;
            }

            if (objectPool.ContainsKey(entry.prefab))
            {
                Debug.LogWarning("Prefab is already in the pool.");
                continue;
            }

            objectPool[entry.prefab] = new Queue<GameObject>();

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
        obj.SetActive(false);
        objectPool[prefab].Enqueue(obj);
        return obj;
    }

    public GameObject GetObjectFromPool(GameObject prefab)
    {
        if (objectPool.ContainsKey(prefab) && objectPool[prefab].Count > 0)
        {
            GameObject pooledObject = objectPool[prefab].Dequeue();
            pooledObject.SetActive(true);
            return pooledObject;
        }
        else
        {
            
            CreateObjectInPool(prefab);
            GameObject pooledObject = objectPool[prefab].Dequeue();
            pooledObject.SetActive(true);
            return pooledObject;
        }
    }

    public void ReturnObjectToPool(GameObject prefab, GameObject obj)
    {
        if (objectPool.ContainsKey(prefab))
        {
            obj.SetActive(false);
            objectPool[prefab].Enqueue(obj);
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

        if (objectPool.ContainsKey(prefab))
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