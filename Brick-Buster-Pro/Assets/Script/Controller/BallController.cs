using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static UnityEditor.Experimental.GraphView.GraphView;


public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigidbody2D;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] AudioSource ballClip;
    [SerializeField] LayerMask layerMask;
    public Vector2 lastBallVelocity;
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

        lastBallVelocity = new Vector2(transform.position.x, transform.position.y);
        if (lastBallVelocity != Vector2.zero)
        {
            ballRigidbody2D.velocity = Vector2.zero;
        }

    }
    public void KeepMoving()
    {

        if (lastBallVelocity != Vector2.zero) { ballRigidbody2D.velocity = lastBallVelocity * gameController.GetBallForce(); }

    }
    public void StrongBall()
    {
        ballPower += 1;
    }
    public void FastAndStrongBall()
    {
        gameController.SetBallForce();
        ballRigidbody2D.velocity = Vector2.one * gameController.GetBallForce();
        ballPower += 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (layerMask == (layerMask | (1 << collision.gameObject.layer)))
        {
            gameController.GetBallList().Remove(gameObject);
            gameObject.SetActive(false);
        }
        if (gameObject.activeSelf == true)
        {
            ballClip.Play();
        }

    }
}
