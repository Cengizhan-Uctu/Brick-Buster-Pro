using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigidbody2D;
    [SerializeField] GameObject ballPrefab;
    private Vector2 lastBallVelocity;
    private IObjectPool objectPool;
    private IGameController gameController;
    public int ballPower;

    [Inject]
    public void SetGameController(IObjectPool objectPoolBall, IGameController gameController)
    {
        this.objectPool = objectPoolBall;
        this.gameController = gameController;
    }

    public void SpawnBall(int ballNumber)
    {
        for (int i = 0; i < ballNumber; i++)
        {
            GameObject newBall = objectPool.GetObjectFromPool(ballPrefab);
            gameController.GetBallList().Add(newBall);
            newBall.transform.position = transform.position;
            
            newBall.GetComponent<Rigidbody2D>().AddForce(transform.position * gameController.GetBallForce(), ForceMode2D.Impulse);
        }
    }
    public void StopBall()
    {
        lastBallVelocity = ballRigidbody2D.velocity;
        ballRigidbody2D.velocity = Vector2.zero;
    }
    public void KeepMoving()
    {
        if (lastBallVelocity!=Vector2.zero) { ballRigidbody2D.velocity = lastBallVelocity; }
        
    }
    public void StrongBall()
    {
        ballPower += 2;
    }
    public void FastAndStrongBall()
    {
        ballRigidbody2D.velocity *= 1.5f;
        ballPower += 1;
    }
}
