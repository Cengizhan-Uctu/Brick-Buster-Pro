using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class MainMenuState : BaseState
{
    private GameControlSM gameControlSM;
    public MainMenuState(GameControlSM stateMachine) : base("MainMenuState", stateMachine){ gameControlSM = ((GameControlSM)stateMachine); }
    public override void Enter()
    {
        base.Enter();
        //gameControlSM.startButton.transform.parent.gameObject.SetActive(true);
        //gameControlSM.startButton.onClick.AddListener(changeStateToInGame);
    
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
    }


}
