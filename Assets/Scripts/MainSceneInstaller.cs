using Interfaces;
using ScriptableObjects;
using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private Transform _poolParent;
    
    public override void InstallBindings()
    {
        Container.Bind<IInputService>().To<InputService>().AsSingle();
        Container.Bind<BulletSpawner>().To<BulletSpawner>().AsSingle();
        
        Container.Bind<BulletFactory>()
            .To<BulletFactory>()
            .AsSingle()
            .WithArguments(_poolParent);
        
        Container.Bind<GameConfig>().FromInstance(_gameConfig).AsSingle().NonLazy();
    }
}