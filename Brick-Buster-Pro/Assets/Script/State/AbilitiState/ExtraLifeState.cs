using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEditor.Progress;

public class ExtraLifeState : BaseState
{
    private GameControlSM gameControlSM;
    
    public ExtraLifeState(GameControlSM stateMachine) : base("ExtraLifeState", stateMachine){ gameControlSM = ((GameControlSM)stateMachine); }
    public override void Enter()
    {
        base.Enter();
        gameControlSM.playerLife++;
        ChangeStateToInGame();
      
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
      
        // do someting
    }

    public override void Exit()
    {
    
       
    }
    void ChangeStateToInGame()
    {
        stateMachine.ChangeState(gameControlSM.moveState);
    }


}
