using Zenject;
using Zenject.Asteroids;

public class TestGameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // Ball.Factory s�n�f� i�in BindFactory kullan�m�
        Container.BindFactory<TestBall, TestBall.Factory>().FromNewComponentOnNewGameObject();
        Container.Bind<TestGameController>().FromComponentInHierarchy().AsSingle();
    }
}