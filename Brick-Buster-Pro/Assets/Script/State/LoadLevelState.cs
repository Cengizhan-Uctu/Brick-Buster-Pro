using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;



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
       
           

        

        LoadBrickMove();
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (gameControlSM.brickListObj.transform.position == gameControlSM.brickListObj.GetComponent<BrickMove>().endPoint) { changeStateToFirstSho(); }
    }

    public override void Exit()
    {
        base.Exit();

        //gameControlSM.startButton.transform.parent.gameObject.SetActive(false);
    }
    void changeStateToFirstSho()
    {
        stateMachine.ChangeState(gameControlSM.firstShotState);
    }
    private void LoadBrickMove()
    {
        gameControlSM.brickListObj.GetComponent<BrickMove>().brickMove();
    }


}
