using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class NextLevelState : BaseState
{
    private GameControlSM gameControlSM;
    public NextLevelState(GameControlSM stateMachine) : base("NextLevelState", stateMachine){ gameControlSM = ((GameControlSM)stateMachine); }
    public override void Enter()
    {
        base.Enter();
        gameControlSM.nextLevelPanel.SetActive(true);
        gameControlSM.nextLevelBtn.onClick.AddListener(changeStateToInGame);

        // Print the highest score.
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
      
        // do someting
    }

    public override void Exit()
    {
        base.Exit();
       
        //gameControlSM.startButton.transform.parent.gameObject.SetActive(false);
    }
    void changeStateToInGame()
    {
        //stateMachine.ChangeState(gameControlSM.inGameState);
        //sahne deðiþtir
        // gidilen o sahne seni geri bu sahneye göndersin
    }


}
