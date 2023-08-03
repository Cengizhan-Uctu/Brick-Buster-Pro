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
        gameControlSM.extensionPlatformBtn.onClick.AddListener(ChangeStateToExtensionPlatformState);
        gameControlSM.platformGunBtn.onClick.AddListener(ChangeStateToPlatformGunState);
        gameControlSM.bigBallBtn.onClick.AddListener(ChangeStateToBiggBallState);
        gameControlSM.smallBallBtn.onClick.AddListener(ChangeStateToSmallBallState);
        gameControlSM.strongBallBtn.onClick.AddListener(ChangeStateToStronglBallState);
        gameControlSM.fastStrongBallBtn.onClick.AddListener(ChangeStateToFastStronglBallState);
        gameControlSM.activeBallBtn.onClick.AddListener(ChangeStateToActiveWallState);
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

            int randomIndex = UnityEngine.Random.Range(i, objectCount);
            GameObject temp = gameControlSM.cardList[randomIndex];
            gameControlSM.cardList[randomIndex] = gameControlSM.cardList[i];
            gameControlSM.cardList[i] = temp;
        }
    }
    void ChangeStateToTreeBall()
    {
        gameControlSM.threeBallBtn.onClick.AddListener(ChangeStateToTreeBall);
        stateMachine.ChangeState(gameControlSM.threeBallState);
    }
    void ChangeStateToExtensionPlatformState()
    {
        gameControlSM.extensionPlatformBtn.onClick.AddListener(ChangeStateToExtensionPlatformState);
        stateMachine.ChangeState(gameControlSM.extensionPlatformState);
    }
    void ChangeStateToPlatformGunState()
    {
        gameControlSM.platformGunBtn.onClick.AddListener(ChangeStateToPlatformGunState);
        stateMachine.ChangeState(gameControlSM.platformGunState);
    }
    void ChangeStateToBiggBallState()
    {
        gameControlSM.bigBallBtn.onClick.AddListener(ChangeStateToBiggBallState);
        stateMachine.ChangeState(gameControlSM.bigBallState);
    }
    void ChangeStateToSmallBallState()
    {
        gameControlSM.smallBallBtn.onClick.AddListener(ChangeStateToSmallBallState);
        stateMachine.ChangeState(gameControlSM.smallBallState);
    }
    void ChangeStateToStronglBallState()
    {
        gameControlSM.strongBallBtn.onClick.AddListener(ChangeStateToStronglBallState);
        stateMachine.ChangeState(gameControlSM.strongBallState);
    }
    void ChangeStateToFastStronglBallState()
    {
        gameControlSM.fastStrongBallBtn.onClick.AddListener(ChangeStateToFastStronglBallState);
        stateMachine.ChangeState(gameControlSM.fastAndStrongBallState);
    }
    void ChangeStateToActiveWallState()
    {
        gameControlSM.activeBallBtn.onClick.AddListener(ChangeStateToActiveWallState);
        stateMachine.ChangeState(gameControlSM.activeWallState);
    }
}
