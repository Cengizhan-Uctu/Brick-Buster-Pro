
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

public class GameInstaller : MonoInstaller 
{

    public GameControlSM gameControlSMPrefab;
    public override void InstallBindings()
    {
        Container.Bind<IGameController>().To<GameControlSM>().FromComponentInNewPrefab(gameControlSMPrefab).AsCached();
    }
}
