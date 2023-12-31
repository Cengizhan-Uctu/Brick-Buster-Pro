using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : BaseState
{
    private GameControlSM gameControlSM;
    public GameOverState(GameControlSM stateMachine) : base("GameOverState", stateMachine){ gameControlSM = ((GameControlSM)stateMachine); }
    public override void Enter()
    {
        base.Enter();
        if (gameControlSM.playerLife == 0)
        {
            gameControlSM.gameoverPanel.SetActive(true);
            gameControlSM.gameOverBtn.onClick.AddListener(changeStateToInGame);
            gameControlSM.playerLife--;
            gameControlSM.selectionPanel.SetActive(false);
        }
        else
        {
            gameControlSM.playerLife--;
        }
     
    }
  

    public override void Exit()
    {
        base.Exit();
        if (gameControlSM.playerLife == 0)
        {
            gameControlSM.gameOverBtn.onClick.RemoveListener(changeStateToInGame);
            gameControlSM.gameoverPanel.SetActive(false);
        }
            
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (gameControlSM.playerLife >= 0)
        {
            stateMachine.ChangeState(gameControlSM.firstShotState);
        }
    }
    void changeStateToInGame()
    {
            SceneManager.LoadScene(0);
    }


}
