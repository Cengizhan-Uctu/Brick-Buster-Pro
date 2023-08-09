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
        gameControlSM.gameoverPanel.SetActive(true);
        gameControlSM.gameOverBtn.onClick.AddListener(changeStateToInGame);
    
     
    }
  

    public override void Exit()
    {
        base.Exit();

        gameControlSM.gameOverBtn.onClick.RemoveListener(changeStateToInGame);
        gameControlSM.gameoverPanel.SetActive(false);
    }
    void changeStateToInGame()
    {
        SceneManager.LoadScene(0);
    }


}
