using DG.Tweening;

public class SmallBallState : BaseState
{
    private GameControlSM gameControlSM;
  
    public SmallBallState(GameControlSM stateMachine) : base("SmallBallState", stateMachine){ gameControlSM = ((GameControlSM)stateMachine); }
    public override void Enter()
    {
        base.Enter();
       
        foreach (var item in gameControlSM.GetBallList())
        {
            item.transform.DOScale(item.transform.localScale*.8f, .3f);
        }
       
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
       
        gameControlSM.bigBallBtn.gameObject.SetActive(false); 
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
