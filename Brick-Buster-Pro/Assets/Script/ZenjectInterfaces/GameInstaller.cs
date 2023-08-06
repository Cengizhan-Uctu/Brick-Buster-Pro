
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

public class GameInstaller : MonoInstaller 
{
    public GameControlSM gameControlSMPrefab;
  
    public ObjectPool objectPool;
    public override void InstallBindings()
    {
        Container.Bind<IGameController>().To<GameControlSM>().FromComponentInNewPrefab(gameControlSMPrefab).AsCached();
       
        Container.Bind<IObjectPool>().To<ObjectPool>().FromComponentInNewPrefab(objectPool).AsCached();
    }
}
