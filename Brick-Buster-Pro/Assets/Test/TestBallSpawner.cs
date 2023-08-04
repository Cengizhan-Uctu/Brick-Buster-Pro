using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BallSpawner : MonoBehaviour
{
    [Inject]
    private TestBall.Factory ballFactory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            // Topu Object Pool'dan al�p sahneye eklemek i�in Spawn metodu kullan�l�r
            TestBall ball = ballFactory.Create();
            ball.transform.position = Vector3.zero;
            ball.gameObject.SetActive(true);

            // Topu kullan�m� tamamland���nda havuza geri vermek i�in Despawn metodu kullan�l�r
            ball.gameObject.SetActive(false);
        }
       
    }
}