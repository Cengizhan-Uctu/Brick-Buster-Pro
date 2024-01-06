using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEditor.Experimental.GraphView.GraphView;


public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigidbody2D;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] AudioSource ballClip;
    [SerializeField] LayerMask layerMask;
    public Vector2 lastBallVelocity;
    
   
    public int ballPower;

    

    public void SpawnBall(int ballNumber)
    {
        for (int i = 0; i < ballNumber; i++)
        {
            GameObject newBall = ObjectPool.Instance.GetObjectFromPool(ballPrefab);
            GameControlSM.Instance.GetBallList().Add(newBall);
            newBall.transform.position = transform.position;
            lastBallVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
            if (newBall.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
            {
                newBall.GetComponent<Rigidbody2D>().AddForce(transform.position * GameControlSM.Instance.GetBallForce(), ForceMode2D.Impulse);
            }
            
        }
    }
    public void StopBall()
    {

        lastBallVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        if (lastBallVelocity != Vector2.zero)
        {
            ballRigidbody2D.velocity = Vector2.zero;
        }

    }
    public void KeepMoving()
    {

        if (lastBallVelocity != Vector2.zero) { ballRigidbody2D.velocity = lastBallVelocity; }

    }
    public void StrongBall()
    {
        ballPower += 1;
    }
    public void FastAndStrongBall()
    {
        GameControlSM.Instance.SetBallForce();
        ballRigidbody2D.velocity = Vector2.one * GameControlSM.Instance.GetBallForce();
        ballPower += 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (layerMask == (layerMask | (1 << collision.gameObject.layer)))
        {
            GameControlSM.Instance.GetBallList().Remove(gameObject);
            gameObject.SetActive(false);
        }
        if (gameObject.activeSelf == true)
        {
            ballClip.Play();
        }

    }
}
