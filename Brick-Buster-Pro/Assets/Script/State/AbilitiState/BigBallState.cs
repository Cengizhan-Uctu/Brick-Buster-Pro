using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Zenject.SpaceFighter;
using static UnityEditor.Progress;

public class BigBallState : BaseState
{
    private GameControlSM gameControlSM;
  
    public BigBallState(GameControlSM stateMachine) : base("BigBallState", stateMachine){ gameControlSM = ((GameControlSM)stateMachine); }
    public override void Enter()
    {
        base.Enter();
        foreach (var item in gameControlSM.GetBallList())
        {
            item.transform.DOScale(item.transform.localScale*1.2f, .3f);
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