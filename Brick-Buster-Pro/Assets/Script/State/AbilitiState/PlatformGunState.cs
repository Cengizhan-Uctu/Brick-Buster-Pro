using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEditor.Progress;

public class PlatformGunState : BaseState
{
    private GameControlSM gameControlSM;
    
    public PlatformGunState(GameControlSM stateMachine) : base("PlatformGunState", stateMachine){ gameControlSM = ((GameControlSM)stateMachine); }
    public override void Enter()
    {
        base.Enter();
        gameControlSM.player.GetComponent<PlayerController>().ActiveGun();
       // silahlarý çalýþtýr 4 saniye sonra kapat
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
