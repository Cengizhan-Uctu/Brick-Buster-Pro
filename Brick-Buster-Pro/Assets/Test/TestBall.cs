using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

public class TestBall : MonoBehaviour
{
    [Inject]
    public TestGameController gameController;

    public class FactoryTest : PlaceholderFactory<TestBall>
    {

    }


    private void OnEnable()
    {
        // Top oluşturulduğunda bu metot çağrılır
        //Debug.Log("Ball is spawned");
        //gameController.HelloWorld();
    }

    private void OnDisable()
    {
        // Top havuza geri verildiğinde bu metot çağrılır
        Debug.Log("Ball is despawned");
    }
}
