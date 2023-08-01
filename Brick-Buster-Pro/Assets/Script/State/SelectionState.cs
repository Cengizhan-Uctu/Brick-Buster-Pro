using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;

public class SelectionState : BaseState
{
    private GameControlSM gameControlSM;
    public SelectionState(GameControlSM stateMachine) : base("SelectionState", stateMachine) { gameControlSM = ((GameControlSM)stateMachine); }
    public override void Enter()
    {
        base.Enter();
        gameControlSM.bounceNumber = 0;
        gameControlSM.bounceSlider.value = 0;
        StopBall();
        gameControlSM.selectionPanel.SetActive(true);
        GetCard();
        gameControlSM.threeBallBtn.onClick.AddListener(ChangeStateToTreeBall);
        //gameControlSM.startButton.onClick.AddListener(changeStateToInGame);
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();


    }

    public override void Exit()
    {
        base.Exit();


    }
  
    void StopBall()
    {
        for (int i = 0; i < gameControlSM.totalBallObjList.Count; i++)
        {
            gameControlSM.totalBallObjList[i].GetComponent<BallController>().StopBall();
        }
    }
    public void GetCard()
    {

       ShuffleCardList();
        for (int i = 0; i < 3; i++)
        {
            gameControlSM.cardList[i].gameObject.SetActive(true);
            gameControlSM.cardList[i].GetComponent<UnityEngine.UI.Image>().rectTransform.DOAnchorPos(gameControlSM.cardPoint[i], .3f);
        }

    }

    private void ShuffleCardList()
    {
        int objectCount = gameControlSM.cardList.Count;

       
        for (int i = 0; i < objectCount - 1; i++)
        {
            
            int randomIndex =UnityEngine.Random.Range(i, objectCount);
            GameObject temp = gameControlSM.cardList[randomIndex];
            gameControlSM.cardList[randomIndex] = gameControlSM.cardList[i];
            gameControlSM.cardList[i] = temp;
        }
    }
    void ChangeStateToTreeBall()
    {
        stateMachine.ChangeState(gameControlSM.threeBallState);
    }
}
