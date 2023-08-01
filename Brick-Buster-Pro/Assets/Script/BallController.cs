using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigidbody2D;
    private Vector2 lastBallVelocity;
    public void StopBall()
    {
        lastBallVelocity = ballRigidbody2D.velocity;
        ballRigidbody2D.velocity = Vector2.zero;    
    }
    public void KeepMoving()
    {
       ballRigidbody2D.velocity = lastBallVelocity;
    }
}
