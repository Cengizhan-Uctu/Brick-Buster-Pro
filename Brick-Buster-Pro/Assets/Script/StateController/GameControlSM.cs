using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameControlSM : StateMachine, IGameController
{

    [HideInInspector] public MainMenuState mainMenuState;
    [HideInInspector] public FirstShotState firstShotState;
    [HideInInspector] public MoveState moveState;
    [HideInInspector] public LoadLevelState loadLevelState;
    [HideInInspector] public SelectionState selectionState;
    [HideInInspector] public ThreeBallState threeBallState;
    [HideInInspector] public ExtensionPlatformState extensionPlatformState;

    [Header("Bounce Slider")]
    public Slider bounceSlider;
    public int bounceSliderMaxValue;
    public int bounceNumber;

    [Header("Load Level State")]

    public GameObject brickListObj;
    public List<GameObject> brickList = new List<GameObject>();
    public Vector3 brickListObjFistPos;
    public Vector3 brickListObjEndPoint;
    public Vector3 playerEndPoint;


    [Header("FirstShotState")]

    public int lineRendererTotalBounce = 3;
    public float lineOfset = .01f;
    public GameObject firstBall;
    public float ballForce;
    public LayerMask layerMask;
    public float minAngle = -90f;
    public float maxAngle = 90f;
    public LineRenderer lineRenderer;//from BallHolder
    public GameObject BallHolder;

    [Header("MoveState")]
    public float moveSpeed = 5f;
    public GameObject player;

    [Header("Pause State")]
    public List<GameObject> totalBallObjList = new List<GameObject>();

    [Header("Selection State")]
    public GameObject selectionPanel;
    public List<GameObject> cardList = new List<GameObject>();
    public Vector2 [] cardPoint;
    [Header("Special Abilities")]
    public Button threeBallBtn;
    public Button extensionPlatformBtn;

    private void Awake()
    {

        mainMenuState = new MainMenuState(this);
        firstShotState = new FirstShotState(this);
        moveState = new MoveState(this);
        loadLevelState = new LoadLevelState(this);
        selectionState = new SelectionState(this);
        threeBallState = new ThreeBallState(this);
        extensionPlatformState = new ExtensionPlatformState(this);

    }

    protected override BaseState GetInitialState()
    {
        return loadLevelState;
    }
    public void RemoveBrick(GameObject brick)
    {
        brickList.Remove(brick);
        bounceNumber++;
        bounceSlider.value = bounceNumber;
    }

    public float GetBallForce()
    {
       return ballForce;
    }

    public List<GameObject> GetBallList()
    {
        return totalBallObjList;
    }
}
