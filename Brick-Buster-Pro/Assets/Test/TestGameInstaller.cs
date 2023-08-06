using System;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

public class TestGameInstaller : MonoInstaller
{
    public GameObject prefab;
    public override void InstallBindings()
    {
        // Ball.Factory sýnýfý için BindFactory kullanýmý
        Container.BindFactory<TestBall, TestBall.FactoryTest>()
             .FromComponentInNewPrefab(prefab)
             .AsSingle();
        Container.Bind<TestGameController>().FromComponentInHierarchy().AsSingle();
    }
}