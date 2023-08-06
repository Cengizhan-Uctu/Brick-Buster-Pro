using System;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

public class TestGameInstaller : MonoInstaller
{
    public GameObject prefab;
    public override void InstallBindings()
    {
        // Ball.Factory s�n�f� i�in BindFactory kullan�m�
        Container.BindFactory<TestBall, TestBall.FactoryTest>()
             .FromComponentInNewPrefab(prefab)
             .AsSingle();
        Container.Bind<TestGameController>().FromComponentInHierarchy().AsSingle();
    }
}