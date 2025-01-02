using Interfaces;
using ScriptableObjects;
using UI;
using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
  [SerializeField] private GameConfig _gameConfig;
  [SerializeField] private GameController _gameController;
  [SerializeField] private Transform _poolParent;
  [SerializeField] private Car.Car _car;
  [SerializeField] private Transform _finishTransform;
  [SerializeField] private CamerasController _camerasController;
  [SerializeField] private StartMenu _startMenu;
  [SerializeField] private ConclusionMenu _conclusionMenu;

  public override void InstallBindings()
  {
    Container.Bind<IInputService>().To<InputService>().AsSingle();
    Container.Bind<GameConfig>().FromInstance(_gameConfig).AsSingle().NonLazy();
    Container.Bind<GameController>().FromInstance(_gameController).AsSingle().NonLazy();
    Container.Bind<Car.Car>().FromInstance(_car).AsSingle();
    Container.Bind<Transform>().FromInstance(_finishTransform).AsSingle();
    Container.Bind<CamerasController>().FromInstance(_camerasController).AsSingle();
    Container.Bind<StartMenu>().FromInstance(_startMenu).AsSingle();
    Container.Bind<ConclusionMenu>().FromInstance(_conclusionMenu).AsSingle();

    Container.Bind<ObjectFactory<Bullet>>()
      .To<ObjectFactory<Bullet>>()
      .AsSingle()
      .WithArguments(_gameConfig.BulletParameters.BulletPrefab, _poolParent);
    
    Container.Bind<ObjectFactory<Enemy.EnemyController>>()
      .To<ObjectFactory<Enemy.EnemyController>>()
      .AsSingle()
      .WithArguments(_gameConfig.EnemyParameters.EnemyControllerPrefab, _poolParent);
        
    Container.Bind<BulletSpawner>().To<BulletSpawner>().AsSingle();
  }
}