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
            // Topu Object Pool'dan alýp sahneye eklemek için Spawn metodu kullanýlýr
            TestBall ball = ballFactory.Create();
            ball.transform.position = Vector3.zero;
            ball.gameObject.SetActive(true);

            // Topu kullanýmý tamamlandýðýnda havuza geri vermek için Despawn metodu kullanýlýr
            ball.gameObject.SetActive(false);
        }
       
    }
}