using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigidbody2D;
    private Vector2 lastBallVelocity;
    private IObjectPoolBall objectPool;
    private IGameController gameController;

    [Inject]
    public void SetGameController(IObjectPoolBall objectPoolBall, IGameController gameController)
    {
        this.objectPool = objectPoolBall;
        this.gameController = gameController;
    }

    public void SpawnBall(int ballNumber)
    {
        for (int i = 0; i < ballNumber; i++)
        {
            GameObject newBall = objectPool.GetObjectFromPool();
            gameController.GetBallList().Add(newBall);
            newBall.transform.position = transform.position;
            Debug.Log(gameController.GetBallForce());
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
}
