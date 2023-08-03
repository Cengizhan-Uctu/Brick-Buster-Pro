using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPoolBullet
{
    public GameObject GetObjectFromPool();
    public void ReturnObjectToPool(GameObject obj);
}
