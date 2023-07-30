using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BrickCollision : MonoBehaviour
{
    private IGameController gameController;

    [Inject]
    public void SetGameController(IGameController gameController)
    {
        this.gameController = gameController;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BallCollision ballCollision))
        {
            
           gameController.RemoveBrick(gameObject);
           gameObject.SetActive(false);

        }
    }
}
