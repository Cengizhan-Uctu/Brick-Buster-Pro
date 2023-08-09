using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseState : BaseState
{
    private GameControlSM gameControlSM;
    public PauseState(GameControlSM stateMachine) : base("PauseState", stateMachine){ gameControlSM = ((GameControlSM)stateMachine); }
    private int currentLevelIndex;
    public override void Enter()
    {
        base.Enter();
        gameControlSM.pausePanel.SetActive(true);
        gameControlSM.resumeBtn.onClick.AddListener(changeStateToInGame);
        for (int i = 0; i < gameControlSM.totalBallObjList.Count; i++)
        {
            gameControlSM.totalBallObjList[i].GetComponent<BallController>().StopBall();
        }

       
    }
    

    public override void Exit()
    {
        base.Exit();
        gameControlSM.nextLevelBtn.onClick.RemoveListener(changeStateToInGame);
        gameControlSM.nextLevelPanel.SetActive(false);
    }
    void changeStateToInGame()
    {
        Resume();
    }
    public void Resume()
    {
        for (int i = 0; i < gameControlSM.totalBallObjList.Count; i++)
        {
            gameControlSM.totalBallObjList[i].GetComponent<BallController>().KeepMoving();
        }
        gameControlSM.pausePanel.SetActive(false);
        stateMachine.ChangeState(gameControlSM.moveState);
    }


}
