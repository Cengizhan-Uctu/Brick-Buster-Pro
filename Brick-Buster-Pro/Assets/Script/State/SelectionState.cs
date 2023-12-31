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
        SetActiveFalseBtn();
        StopBall();
        gameControlSM.selectionPanel.SetActive(true);
        GetCard();
        AddListenerBtn();
       // gameControlSM.SetIsMove(false);
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();


    }

    public override void Exit()
    {
        base.Exit();
      
        RemoveListenerBtn();
       // gameControlSM.SetIsMove(true);
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

        stateMachine.ChangeState(gameControlSM.threeBallState);
    }
    void ChangeStateToExtensionPlatformState()
    {

        stateMachine.ChangeState(gameControlSM.extensionPlatformState);
    }
    void ChangeStateToPlatformGunState()
    {

        stateMachine.ChangeState(gameControlSM.platformGunState);
    }
    void ChangeStateToBiggBallState()
    {

        stateMachine.ChangeState(gameControlSM.bigBallState);
    }
    void ChangeStateToSmallBallState()
    {

        stateMachine.ChangeState(gameControlSM.smallBallState);
    }
    void ChangeStateToStronglBallState()
    {

        stateMachine.ChangeState(gameControlSM.strongBallState);
    }
    void ChangeStateToFastStronglBallState()
    {

        stateMachine.ChangeState(gameControlSM.fastAndStrongBallState);
    }
    void ChangeStateToActiveWallState()
    {

        stateMachine.ChangeState(gameControlSM.activeWallState);
    }
    void ChangeStateToExtraLife()
    {
       
        stateMachine.ChangeState(gameControlSM.extraLifeState);
    }
    void AddListenerBtn()
    {
        gameControlSM.threeBallBtn.onClick.AddListener(ChangeStateToTreeBall);
        gameControlSM.extensionPlatformBtn.onClick.AddListener(ChangeStateToExtensionPlatformState);
        gameControlSM.platformGunBtn.onClick.AddListener(ChangeStateToPlatformGunState);
        gameControlSM.bigBallBtn.onClick.AddListener(ChangeStateToBiggBallState);
        gameControlSM.smallBallBtn.onClick.AddListener(ChangeStateToSmallBallState);
        gameControlSM.strongBallBtn.onClick.AddListener(ChangeStateToStronglBallState);
        gameControlSM.fastStrongBallBtn.onClick.AddListener(ChangeStateToFastStronglBallState);
        gameControlSM.activeBallBtn.onClick.AddListener(ChangeStateToActiveWallState);
        gameControlSM.extraLifeBtn.onClick.AddListener(ChangeStateToExtraLife);
    }
    void RemoveListenerBtn()
    {
        gameControlSM.threeBallBtn.onClick.RemoveListener(ChangeStateToTreeBall);
        gameControlSM.extensionPlatformBtn.onClick.RemoveListener(ChangeStateToExtensionPlatformState);
        gameControlSM.platformGunBtn.onClick.RemoveListener(ChangeStateToPlatformGunState);
        gameControlSM.bigBallBtn.onClick.RemoveListener(ChangeStateToBiggBallState);
        gameControlSM.smallBallBtn.onClick.RemoveListener(ChangeStateToSmallBallState);
        gameControlSM.strongBallBtn.onClick.RemoveListener(ChangeStateToStronglBallState);
        gameControlSM.fastStrongBallBtn.onClick.RemoveListener(ChangeStateToFastStronglBallState);
        gameControlSM.activeBallBtn.onClick.RemoveListener(ChangeStateToActiveWallState);
        gameControlSM.extraLifeBtn.onClick.RemoveListener(ChangeStateToExtraLife);
    }
    void SetActiveFalseBtn()
    {
        gameControlSM.threeBallBtn.gameObject.SetActive(false);
        gameControlSM.extensionPlatformBtn.gameObject.SetActive(false);
        gameControlSM.platformGunBtn.gameObject.SetActive(false);
        gameControlSM.bigBallBtn.gameObject.SetActive(false);
        gameControlSM.smallBallBtn.gameObject.SetActive(false);
        gameControlSM.strongBallBtn.gameObject.SetActive(false);
        gameControlSM.fastStrongBallBtn.gameObject.SetActive(false);
        gameControlSM.activeBallBtn.gameObject.SetActive(false);
        gameControlSM.extraLifeBtn.gameObject.SetActive(false);
    }
}
