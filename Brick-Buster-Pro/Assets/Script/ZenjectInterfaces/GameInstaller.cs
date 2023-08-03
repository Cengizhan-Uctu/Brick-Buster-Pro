
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

public class GameInstaller : MonoInstaller 
{
    public GameControlSM gameControlSMPrefab;
    public BulletObjectPool bulletObjectPoolPrefab;
    public BallObjectPool ballObjectPoolPrefab;
    public override void InstallBindings()
    {
        Container.Bind<IGameController>().To<GameControlSM>().FromComponentInNewPrefab(gameControlSMPrefab).AsCached();
        Container.Bind<IObjectPoolBall>().To<BallObjectPool>().FromComponentInNewPrefab(ballObjectPoolPrefab).AsCached();
        Container.Bind<IObjectPoolBullet>().To<BulletObjectPool>().FromComponentInNewPrefab(bulletObjectPoolPrefab).AsCached();
    }
}
