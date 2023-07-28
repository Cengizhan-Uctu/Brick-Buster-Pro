using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using DG.Tweening;



public class LoadLevelState : BaseState
{
    private GameControlSM gameControlSM;
    public LoadLevelState(GameControlSM stateMachine) : base("LoadLevelState", stateMachine) { gameControlSM = ((GameControlSM)stateMachine); }
    public override void Enter()
    {
        base.Enter();
        for (int i = 0; i < gameControlSM.brickListObj.transform.childCount; i++)
        {
            gameControlSM.brickList.Add(gameControlSM.brickListObj.transform.GetChild(i).gameObject);
        }
        gameControlSM.brickListObj.transform.position = gameControlSM.brickListObjFistPos;
        gameControlSM.player.transform.position = gameControlSM.brickListObjFistPos;
        gameControlSM.firstBall.SetActive(false);

        BrickMove();

        
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
    }

    public override void Exit()
    {
        base.Exit();

        //gameControlSM.startButton.transform.parent.gameObject.SetActive(false);
    }
    void changeStateToFirstSho()
    {
        gameControlSM.firstBall.SetActive(true);
        stateMachine.ChangeState(gameControlSM.firstShotState);
    }
   

    public void BrickMove()
    {
       gameControlSM.brickListObj.transform.DOMove(gameControlSM.  brickListObjEndPoint, .9f).SetEase(Ease.OutBack);
       gameControlSM.player.transform.DOMove(gameControlSM.playerEndPoint, .9f).SetEase(Ease.OutBack).OnComplete(() => changeStateToFirstSho());
    }
}
