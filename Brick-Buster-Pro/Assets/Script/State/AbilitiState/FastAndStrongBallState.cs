using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Zenject.SpaceFighter;
using static UnityEditor.Progress;

public class FastAndStrongBallState : BaseState
{
    private GameControlSM gameControlSM;
  
    public FastAndStrongBallState(GameControlSM stateMachine) : base("FastAndStrongBallState", stateMachine){ gameControlSM = ((GameControlSM)stateMachine); }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enter FastAndStrongBallState");
        foreach (var item in gameControlSM.GetBallList())
        {
            item.GetComponent<BallController>().FastAndStrongBall();
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
        Debug.Log("Exit FastAndStrongBallState");
        gameControlSM.bigBallBtn.gameObject.SetActive(false); 
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
