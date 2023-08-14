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
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 dragStartPosition;
    public MoveState(GameControlSM stateMachine) : base("MoveState", stateMachine) { gameControlSM = ((GameControlSM)stateMachine); }
    public override void Enter()
    {
        base.Enter();
        gameControlSM.totalBallObjList.Add(gameControlSM.firstBall);
        gameControlSM.bounceSlider.maxValue = gameControlSM.bounceSliderMaxValue;
        gameControlSM.pauseBtn.onClick.AddListener(CheckPause);
      
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

    }

    private void MovePlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragStartPosition.y = gameControlSM.player.transform.position.y; // Sadece y eksenindeki de�eri koru
            dragStartPosition.z = gameControlSM.player.transform.position.z;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentDragPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentDragPosition.y = gameControlSM.player.transform.position.y; // Sadece y eksenindeki de�eri koru
            currentDragPosition.z = gameControlSM.player.transform.position.z;

            Vector3 dragDelta = currentDragPosition - dragStartPosition;
            Vector3 newPosition = gameControlSM.player.transform.position + dragDelta;

            newPosition.x = Mathf.Clamp(newPosition.x, gameControlSM.minXValue, gameControlSM.maxXValue);

            gameControlSM.player.transform.position = Vector3.Lerp(gameControlSM.player.transform.position, newPosition, gameControlSM.moveSpeed * Time.deltaTime);
        }

    }
    private bool IsObjectTouched(Vector3 mousePosition)
    {
        float distanceThreshold = 0.5f;
        float distance = Vector3.Distance(gameControlSM.player.transform.position, mousePosition);
        return distance < distanceThreshold;
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
