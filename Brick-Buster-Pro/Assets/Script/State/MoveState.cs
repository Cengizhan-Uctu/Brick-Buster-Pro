using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MoveState : BaseState
{
    private GameControlSM gameControlSM;
    private Vector3 dragStartPosition;
    public MoveState(GameControlSM stateMachine) : base("MoveState", stateMachine) { gameControlSM = ((GameControlSM)stateMachine); }
    public override void Enter()
    {
        base.Enter();
        if (gameControlSM.totalBallObjList.Count==0) { gameControlSM.totalBallObjList.Add(gameControlSM.firstBall); }
       
        gameControlSM.bounceSlider.maxValue = gameControlSM.bounceSliderMaxValue;
        gameControlSM.pauseBtn.onClick.AddListener(CheckPause);
        gameControlSM.playerIsMove = true;
      
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();

        MovePlayer();
        CheckCollisionCount();
        CheckBrickCount();
        CheckGameOver();
    }
    public override void Exit()
    {
        base.Exit();
        gameControlSM.pauseBtn.onClick.RemoveListener(CheckPause);
        gameControlSM.SetIsMove(false);
      
    }

    private void MovePlayer()
    {
       
        if (gameControlSM.playerIsMove == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                dragStartPosition.y = gameControlSM.player.transform.position.y; // Sadece y eksenindeki deðeri koru
                dragStartPosition.z = gameControlSM.player.transform.position.z;
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 currentDragPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentDragPosition.y = gameControlSM.player.transform.position.y; // Sadece y eksenindeki deðeri koru
                currentDragPosition.z = gameControlSM.player.transform.position.z;

                Vector3 dragDelta = currentDragPosition - dragStartPosition;
               
                Vector3 newPosition = gameControlSM.player.transform.position + dragDelta.normalized*Time.deltaTime*gameControlSM.moveSpeed;

                newPosition.x = Mathf.Clamp(newPosition.x, gameControlSM.minXValue, gameControlSM.maxXValue);

                gameControlSM.player.transform.position = newPosition;
            }
        }
       

    }
    void CheckBrickCount()
    {
        if (gameControlSM.brickList.Count == 0)
        {
            stateMachine.ChangeState(gameControlSM.nextLevelState);
        }
    }
    void CheckCollisionCount()
    {
        if (gameControlSM.bounceNumber >= gameControlSM.bounceSliderMaxValue)
        {
            stateMachine.ChangeState(gameControlSM.selectionState);

        }

    }
    void CheckGameOver()
    {
        if (gameControlSM.totalBallObjList.Count<=0)
        {
            stateMachine.ChangeState(gameControlSM.gameOverState);
        }
    }
    void CheckPause()
    {
        stateMachine.ChangeState(gameControlSM.pauseState);
    }
}
