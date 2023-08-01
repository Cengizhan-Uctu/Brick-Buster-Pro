using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPoolBall
{
    public GameObject GetObjectFromPool();
    public void ReturnObjectToPool(GameObject obj);
}
