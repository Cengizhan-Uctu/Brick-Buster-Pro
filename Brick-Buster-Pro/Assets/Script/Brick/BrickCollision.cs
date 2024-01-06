using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrickCollision : MonoBehaviour
{
   
    [SerializeField] int birckHealth;
    [SerializeField] TMP_Text brickHealthText;
    [SerializeField] ParticleSystem brickBlodEffect;
   
    private void Start()
    {
        brickHealthText.text = birckHealth.ToString();
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BallController ballController))
        {

            BrickDecrease(ballController.ballPower);

        }
    }
    public void BrickDecrease(int pover)
    {
        birckHealth -= pover;
        GameControlSM.Instance .CollisionCounter(pover);
        if (birckHealth <= 0)
        {

            brickBlodEffect.Play();
            brickBlodEffect.transform.parent=null;
            GameControlSM.Instance.RemoveBrick(gameObject);
           
            gameObject.SetActive(false);
        }
        brickHealthText.text = birckHealth.ToString();
    }
}
