using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPool 
{
    public GameObject GetObjectFromPool(GameObject prefab);
    public void ReturnObjectToPool(GameObject prefab, GameObject obj);
}
