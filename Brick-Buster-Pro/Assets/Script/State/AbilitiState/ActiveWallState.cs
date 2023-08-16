using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Zenject.SpaceFighter;
using static UnityEditor.Progress;

public class ActiveWallState : BaseState
{
    private GameControlSM gameControlSM;
  
    public ActiveWallState(GameControlSM stateMachine) : base("ActiveWallState", stateMachine){ gameControlSM = ((GameControlSM)stateMachine); }
    public override void Enter()
    {
        base.Enter();
       
        gameControlSM.activeWall.GetComponent<ActiveWallControler>().StartActiveWall();
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
      
        gameControlSM.extensionPlatformBtn.gameObject.SetActive(false); 
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
