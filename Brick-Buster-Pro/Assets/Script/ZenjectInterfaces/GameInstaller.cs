
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

public class GameInstaller : MonoInstaller 
{

    public GameControlSM gameControlSMPrefab;
    public BallObjectPool ballObjectPoolPrefab;
    public override void InstallBindings()
    {
        Container.Bind<IGameController>().To<GameControlSM>().FromComponentInNewPrefab(gameControlSMPrefab).AsCached();
        Container.Bind<IObjectPoolBall>().To<BallObjectPool>().FromComponentInNewPrefab(ballObjectPoolPrefab).AsCached();
    }
}
