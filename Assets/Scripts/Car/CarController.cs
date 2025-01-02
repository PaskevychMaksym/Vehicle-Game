using System;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Car
{
  public class CarController : MonoBehaviour
  {
    public event Action OnDestroyed;
    
    [SerializeField] private CarMover _carMover;
    [SerializeField] private CarVisualEffects _carVisualEffects;
    [SerializeField] private HealthSlider _healthSlider;
    
    private Health _health;
    private Transform _followCameraTransform;

    private GameConfig _gameConfig;

    public Health Health => _health;

    [Inject]
    private void Construct(GameConfig gameConfig, 
      GameController gameController,
      CamerasController camerasController)
    {
      _gameConfig = gameConfig;
      _followCameraTransform = camerasController.GetCamera(Enums.CameraType.Follow).transform;

      gameController.OnGameStarted += StartCar;
      gameController.OnGameEnded += StopCar;
    }

    private void Awake()
    {
      var carParameters = _gameConfig.CarParameters;
      _carMover.Initialize(carParameters.Speed);

      _health = new Health(carParameters.MaxHealth);
      _health.OnDeath +=  CarDestroyed;

      _carMover.ToggleEngine(false);
    }

    private void StartCar()
    {
      _carMover.ToggleEngine(true);
      _healthSlider.Initialize(_health,_followCameraTransform);
    }
    
    private void StopCar()
    {
      _carMover.ToggleEngine(false);
    }

    public void TakeDamage(int damage)
    {
     _health.TakeDamage(damage);
     _healthSlider.UpdateSlider();
    }

    private void CarDestroyed()
    {
      _carMover.ToggleEngine(false);
      _carVisualEffects.TriggerExplosion();
      
      OnDestroyed?.Invoke();
    }
  }
}