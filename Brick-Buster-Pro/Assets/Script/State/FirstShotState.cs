using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class FirstShotState : BaseState
{
    private RaycastHit2D hit;
    private GameControlSM gameControlSM;
    public FirstShotState(GameControlSM stateMachine) : base("FirstShotState", stateMachine) { gameControlSM = ((GameControlSM)stateMachine); }
    public override void Enter()
    {
        base.Enter();
        gameControlSM.firstBall.transform.position=gameControlSM.BallHolder.transform.position;
        gameControlSM.firstBall.SetActive(true);
        gameControlSM.lineRenderer.enabled = false;
        gameControlSM.lineRenderer.positionCount = gameControlSM.lineRendererTotalBounce;
        gameControlSM.SetIsMove(false);
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();

        RotateAimTowardsMouse();
        lineRender();
        BallShot();
    }

    public override void Exit()
    {
        base.Exit();
        gameControlSM.lineRenderer.enabled = false;
        //gameControlSM.SetIsMove(true);
        
    }
    void changeStateToMove()
    {
        stateMachine.ChangeState(gameControlSM.moveState);
       
    }
    void RotateAimTowardsMouse()
    {
        Vector3 objectScreenPosition = Camera.main.WorldToScreenPoint(gameControlSM.BallHolder.transform.position);
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = objectScreenPosition.z;
        Vector3 direction = mouseScreenPosition - objectScreenPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, gameControlSM.minAngle, gameControlSM.maxAngle);
        gameControlSM.BallHolder.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void lineRender()
    {
        Vector2 direction = gameControlSM.BallHolder.transform.right;
        Vector2 origin = (Vector2)gameControlSM.BallHolder.transform.position + gameControlSM.lineOfset * direction;
        for (int i = 0; i < gameControlSM.lineRendererTotalBounce; i++)
        {
            hit = Physics2D.Raycast(origin, direction, Mathf.Infinity, gameControlSM.layerMask);
            gameControlSM.lineRenderer.SetPosition(i, origin);
            direction = Vector2.Reflect(direction.normalized, hit.normal);
            origin = hit.point + gameControlSM.lineOfset * direction;
        }
    }
    void BallShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameControlSM.lineRenderer.enabled = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            gameControlSM.firstBall.transform.parent = null;
            gameControlSM.firstBall.GetComponent<Rigidbody2D>().AddForce(gameControlSM.BallHolder.transform.right * gameControlSM.ballForce, ForceMode2D.Impulse);
            
            changeStateToMove();
        }
    }


}
