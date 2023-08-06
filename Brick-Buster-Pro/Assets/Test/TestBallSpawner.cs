using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BallSpawner : MonoBehaviour
   
{
    [SerializeField] ObjectPool objpool;
    [SerializeField] GameObject obj;
    [Inject]
    private TestBall.FactoryTest ballFactory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
           objpool.GetObjectFromPool(obj);
        }
       
    }
}