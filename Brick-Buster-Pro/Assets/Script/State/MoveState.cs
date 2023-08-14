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
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.y = gameControlSM.player.transform.position.y;
            mousePosition.z = gameControlSM.player.transform.position.z;

            if (IsObjectTouched(mousePosition))
            {
                isDragging = true;
                offset = gameControlSM.player.transform.position - mousePosition;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.y = gameControlSM.player.transform.position.y;
            mousePosition.z = gameControlSM.player.transform.position.z;

            float minX = gameControlSM.yourMinXValue; 
            float maxX = gameControlSM.yourMaxXValue;
            float clampedX = Mathf.Clamp(mousePosition.x + offset.x, minX, maxX);

            gameControlSM.player.transform.position = new Vector3(clampedX, gameControlSM.player.transform.position.y, gameControlSM.player.transform.position.z);
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
