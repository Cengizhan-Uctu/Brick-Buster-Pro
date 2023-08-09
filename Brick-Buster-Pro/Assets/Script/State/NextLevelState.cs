using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelState : BaseState
{
    private GameControlSM gameControlSM;
    public NextLevelState(GameControlSM stateMachine) : base("NextLevelState", stateMachine){ gameControlSM = ((GameControlSM)stateMachine); }
    private int currentLevelIndex;
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
        gameControlSM.nextLevelBtn.onClick.RemoveListener(changeStateToInGame);
        gameControlSM.nextLevelPanel.SetActive(false);
    }
    void changeStateToInGame()
    {
        LoadNextLevel();
    }
    public void LoadNextLevel()
    {
        currentLevelIndex = PlayerPrefs.GetInt("LastCompletedLevel", 0);
        int nextLevelIndex = currentLevelIndex + 1;
        PlayerPrefs.SetInt("LastCompletedLevel", nextLevelIndex);
        PlayerPrefs.Save();

        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("LastCompletedLevel", 0));
        }
        else
        {
            
            Debug.Log("LastLevel!");
        }
    }


}
