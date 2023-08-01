using System.Collections.Generic;
using UnityEngine;

public class BallObjectPool : MonoBehaviour,IObjectPoolBall
{
    public GameObject prefab;
    public int poolSize = 10;
    public bool expandable = true;

    private Queue<GameObject> objectPool = new Queue<GameObject>();

    private void Start()
    {
       
        for (int i = 0; i < poolSize; i++)
        {
            CreateObject();
        }
    }

    private void CreateObject()
    {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);
        objectPool.Enqueue(obj);
    }

    public GameObject GetObjectFromPool()
    {
        if (objectPool.Count == 0)
        {
            if (expandable)
            {
                CreateObject();
            }
            else
            {
                return null;
            }
        }

        GameObject obj = objectPool.Dequeue();
        obj.SetActive(true);
        return obj;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
        objectPool.Enqueue(obj);
    }
}
