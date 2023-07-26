using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MoveState : BaseState
{
    private GameControlSM gameControlSM;
    private bool isDragging = false;
    private Vector3 offset;
    public MoveState(GameControlSM stateMachine) : base("MoveState", stateMachine){ gameControlSM = ((GameControlSM)stateMachine); }
    public override void Enter()
    {
        base.Enter();
       
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();

        MovePlayer();
    }
    public override void Exit()
    {
        base.Exit();

        
    }
    void changeStateToInGame()
    {
        //stateMachine.ChangeState(gameControlSM.inGameState);
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

            gameControlSM.player.transform.position = new Vector3(mousePosition.x + offset.x, gameControlSM.player.transform.position.y, gameControlSM.player.transform.position.z);
        }
    }
    private bool IsObjectTouched(Vector3 mousePosition)
    {
        float distanceThreshold = 0.5f; 
        float distance = Vector3.Distance(gameControlSM.player.transform.position, mousePosition);
        return distance < distanceThreshold;
    }

}
