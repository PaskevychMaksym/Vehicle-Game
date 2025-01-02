using InputHandler;
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
    [SerializeField] private Car.CarController _carController;
    [SerializeField] private FinishLine _finishLine;
    [SerializeField] private CamerasController _camerasController;
    [SerializeField] private StartMenu _startMenu;
    [SerializeField] private ConclusionMenu _conclusionMenu;

    public override void InstallBindings()
    {
        ConfigureInputBindings();
        ConfigureGameBindings();
        ConfigureObjectFactories();
        ConfigureUIBindings();
    }

    private void ConfigureInputBindings()
    {
        if (Application.isMobilePlatform)
        {
            Container.Bind<IInputProvider>().To<TouchInputProvider>().AsSingle();
        } else
        {
            Container.Bind<IInputProvider>().To<MouseInputProvider>().AsSingle();
        }

        Container.Bind<IInputService>().To<InputService>().AsSingle();
    }

    private void ConfigureGameBindings()
    {
        Container.Bind<GameConfig>().FromInstance(_gameConfig).AsSingle();
        Container.Bind<GameController>().FromInstance(_gameController).AsSingle();
        Container.Bind<Car.CarController>().FromInstance(_carController).AsSingle();
        Container.Bind<FinishLine>().FromInstance(_finishLine).AsSingle();
    }

    private void ConfigureObjectFactories()
    {
        Container.Bind<ObjectFactory<Bullet.Bullet>>()
            .To<ObjectFactory<Bullet.Bullet>>()
            .AsSingle()
            .WithArguments(_gameConfig.BulletParameters.BulletPrefab, _poolParent);

        Container.Bind<ObjectFactory<Enemy.EnemyController>>()
            .To<ObjectFactory<Enemy.EnemyController>>()
            .AsSingle()
            .WithArguments(_gameConfig.EnemyParameters.EnemyControllerPrefab, _poolParent);

        Container.Bind<BulletSpawner>().To<BulletSpawner>().AsSingle();
    }

    private void ConfigureUIBindings()
    {
        Container.Bind<CamerasController>().FromInstance(_camerasController).AsSingle();
        Container.Bind<StartMenu>().FromInstance(_startMenu).AsSingle();
        Container.Bind<ConclusionMenu>().FromInstance(_conclusionMenu).AsSingle();
    }
}
