using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;

public class BrickCollision : MonoBehaviour
{
    private IGameController gameController;
    [SerializeField] int birckHealth;
    [SerializeField] TMP_Text brickHealthText;
    [Inject]
    public void SetGameController(IGameController gameController)
    {
        this.gameController = gameController;
    }
    private void Start()
    {
        brickHealthText.text = birckHealth.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BallController ballController))
        {

            BrickIncrase(ballController.ballPower);

        }
    }
    void BrickIncrase(int pover)
    {
        birckHealth-=pover;
        gameController.CollisionCounter();
        if (birckHealth <= 0)
        {
            gameController.RemoveBrick(gameObject);
            gameObject.SetActive(false);
        }
        brickHealthText.text= birckHealth.ToString();
    }
}
