using Interfaces;
using ScriptableObjects;
using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
  [SerializeField] private GameConfig _gameConfig;
  [SerializeField] private Transform _poolParent;
  [SerializeField] private Car.Car _car;
  [SerializeField] private Transform _finishTransform;

  public override void InstallBindings()
  {
    Container.Bind<IInputService>().To<InputService>().AsSingle();
    Container.Bind<GameConfig>().FromInstance(_gameConfig).AsSingle().NonLazy();
    Container.Bind<Car.Car>().FromInstance(_car).AsSingle();
    Container.Bind<Transform>().FromInstance(_finishTransform).AsSingle();

    Container.Bind<ObjectFactory<Bullet>>()
      .To<ObjectFactory<Bullet>>()
      .AsSingle()
      .WithArguments(_gameConfig.BulletParameters.BulletPrefab, _poolParent);
    
    Container.Bind<ObjectFactory<Enemy>>()
      .To<ObjectFactory<Enemy>>()
      .AsSingle()
      .WithArguments(_gameConfig.EnemyParameters.EnemyPrefab, _poolParent);
        
    Container.Bind<BulletSpawner>().To<BulletSpawner>().AsSingle();
  }
}