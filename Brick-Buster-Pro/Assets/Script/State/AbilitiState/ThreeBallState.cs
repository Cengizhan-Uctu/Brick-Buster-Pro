using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEditor.Progress;

public class ThreeBallState : BaseState
{
    private GameControlSM gameControlSM;
    private int activeBallCount;
    public ThreeBallState(GameControlSM stateMachine) : base("ThreeBallState", stateMachine){ gameControlSM = ((GameControlSM)stateMachine); }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enter ThreeBallState");
        activeBallCount = gameControlSM.totalBallObjList.Count ;
        for (int i = 0; i < activeBallCount; i++)
        {
            gameControlSM.GetBallList()[i].GetComponent<BallController>().SpawnBall(2);
        }
        changeStateToInGame();
      
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
      
        // do someting
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exit ThreeBallState");
        gameControlSM.threeBallBtn.gameObject.SetActive(false);
        gameControlSM.selectionPanel.SetActive(false);
        for (int i = 0; i < gameControlSM.totalBallObjList.Count; i++)
        {
            gameControlSM.totalBallObjList[i].gameObject.GetComponent<BallController>().KeepMoving();
        }
      
       
    }
    void changeStateToInGame()
    {
        stateMachine.ChangeState(gameControlSM.moveState);
    }


}
