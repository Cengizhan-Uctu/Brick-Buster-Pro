using Zenject;
using Zenject.Asteroids;

public class TestGameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // Ball.Factory sýnýfý için BindFactory kullanýmý
        Container.BindFactory<TestBall, TestBall.Factory>().FromNewComponentOnNewGameObject();
        Container.Bind<TestGameController>().FromComponentInHierarchy().AsSingle();
    }
}