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
        // Top olu�turuldu�unda bu metot �a�r�l�r
        //Debug.Log("Ball is spawned");
        //gameController.HelloWorld();
    }

    private void OnDisable()
    {
        // Top havuza geri verildi�inde bu metot �a�r�l�r
        Debug.Log("Ball is despawned");
    }
}
