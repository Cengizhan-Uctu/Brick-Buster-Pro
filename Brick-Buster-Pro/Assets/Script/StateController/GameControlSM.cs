using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameControlSM : StateMachine
{

    [HideInInspector] public MainMenuState mainMenuState;
    [HideInInspector] public FirstShotState firstShotState;
    [HideInInspector] public MoveState moveState;
    [HideInInspector] public LoadLevelState loadLevelState;

    [Header("Brick list")]
    
    public GameObject brickListObj;
    public List<GameObject> brickList=new List<GameObject>();

    [Header("FirstShotState")]

    public int totalBounce = 3;
    public float lineOfset = .01f;
    public GameObject firstBall;
    public float ballForce = 10;
    public LayerMask layerMask;
    public float minAngle = -90f;
    public float maxAngle = 90f;
    public LineRenderer lineRenderer;//from BallHolder
    public GameObject BallHolder;

    [Header("MoveState")]
    public float moveSpeed = 5f;
    public GameObject player;
    private void Awake()
    {
        mainMenuState = new MainMenuState(this);
        firstShotState = new FirstShotState(this);
        moveState = new MoveState(this);
        loadLevelState = new LoadLevelState(this);

    }
    protected override BaseState GetInitialState()
    {
        return loadLevelState;
    }

}
