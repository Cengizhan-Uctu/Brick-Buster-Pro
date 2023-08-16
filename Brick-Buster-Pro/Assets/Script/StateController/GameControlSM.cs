using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    [HideInInspector] public PlatformGunState platformGunState;
    [HideInInspector] public BigBallState bigBallState;
    [HideInInspector] public SmallBallState smallBallState;
    [HideInInspector] public StrongBallState strongBallState;
    [HideInInspector] public FastAndStrongBallState fastAndStrongBallState;
    [HideInInspector] public ActiveWallState activeWallState;
    [HideInInspector] public GameOverState gameOverState;
    [HideInInspector] public NextLevelState nextLevelState;
    [HideInInspector] public PauseState pauseState;
    [HideInInspector] public ExtraLifeState extraLifeState;


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
    public bool playerIsMove;
    public float minXValue;
    public float maxXValue;

    [Header("Pause State")]
    public List<GameObject> totalBallObjList = new List<GameObject>();
    [Header("activeWall State")]
    public GameObject activeWall;

    [Header("Selection State")]
    public GameObject selectionPanel;
    public List<GameObject> cardList = new List<GameObject>();
    public Vector2[] cardPoint;
    [Header("GameOver State")]
    public GameObject gameoverPanel;
    public Button gameOverBtn;
    public int playerLife;
    [Header("NextLevel State")]
    public GameObject nextLevelPanel;
    public Button nextLevelBtn;
    [Header("Pause State")]
    public GameObject pausePanel;
    public Button pauseBtn;
    public Button resumeBtn;
   
    [Header("Special Abilities")]
    public Button threeBallBtn;
    public Button extensionPlatformBtn;
    public Button platformGunBtn;
    public Button bigBallBtn;
    public Button smallBallBtn;
    public Button strongBallBtn;
    public Button fastStrongBallBtn;
    public Button activeBallBtn;
    public Button extraLife;
    private void Awake()
    {

        mainMenuState = new MainMenuState(this);
        firstShotState = new FirstShotState(this);
        moveState = new MoveState(this);
        loadLevelState = new LoadLevelState(this);
        selectionState = new SelectionState(this);
        threeBallState = new ThreeBallState(this);
        extensionPlatformState = new ExtensionPlatformState(this);
        platformGunState = new PlatformGunState(this);
        bigBallState = new BigBallState(this);
        smallBallState = new SmallBallState(this);
        strongBallState = new StrongBallState(this);
        fastAndStrongBallState = new FastAndStrongBallState(this);
        activeWallState = new ActiveWallState(this);
        gameOverState = new GameOverState(this);
        nextLevelState = new NextLevelState(this);
        pauseState = new PauseState(this);
        extraLifeState = new ExtraLifeState(this);
    }

    protected override BaseState GetInitialState()
    {
        return loadLevelState;
    }
    public void RemoveBrick(GameObject brick)
    {
        brickList.Remove(brick);

    }

    public float GetBallForce()
    {
        return ballForce;
    }

    public List<GameObject> GetBallList()
    {
        return totalBallObjList;
    }

    public void CollisionCounter(int strong)
    {
        bounceNumber += strong;
        bounceSlider.value = bounceNumber;
    }

    public void SetBallForce()
    {
        ballForce++;
    }
    public void SetIsMove(bool isMove)
    {
        playerIsMove = isMove;
    }
}
