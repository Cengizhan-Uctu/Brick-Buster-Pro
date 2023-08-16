using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Zenject.SpaceFighter;
using static UnityEditor.Progress;

public class ExtensionPlatformState : BaseState
{
    private GameControlSM gameControlSM;
  
    public ExtensionPlatformState(GameControlSM stateMachine) : base("ExtensionPlatformState", stateMachine){ gameControlSM = ((GameControlSM)stateMachine); }
    public override void Enter()
    {
        base.Enter();
       
        gameControlSM.player.transform.DOScaleX(gameControlSM.player.transform.localScale.x + .5f, .3f);
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
