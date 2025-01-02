using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Car
{
  public class CarController : MonoBehaviour
  {
    [SerializeField] private CarMover _carMover;
    [SerializeField] private HealthSlider _healthSlider;
    
    private Health _health;
    private Transform _followCameraTransform;

    private GameConfig _gameConfig;
    private GameController _gameController;

    public Health Health => _health;

    [Inject]
    private void Construct(GameConfig gameConfig, 
      GameController gameController,
      CamerasController camerasController)
    {
      _gameConfig = gameConfig;
      _gameController = gameController;
      _followCameraTransform = camerasController.GetCamera(Enums.CameraType.Follow).transform;

      _gameController.OnGameStarted += StartCar;
      _gameController.OnGameEnded += StopCar;
    }

    private void Awake()
    {
      var carParameters = _gameConfig.CarParameters;
      _carMover.Initialize(carParameters.Speed);

      _health = new Health(carParameters.MaxHealth);
      _health.OnDeath +=  CarDestroyed;
      
      _healthSlider.Initialize(_health,_followCameraTransform);

      _carMover.ToggleEngine(false);
    }

    private void OnDestroy()
    {
      _gameController.OnGameStarted -= StartCar;
      _gameController.OnGameEnded -= StopCar;
    }

    private void StartCar()
    {
      _carMover.ToggleEngine(true);
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
      _gameController.EndGame(false);
    }
  }
}