using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Car
{
  public class Car : MonoBehaviour
  {
    private CarMover _carMover;
    private int _maxHealth;
    private int _currentHealth;

    private GameConfig _gameConfig;
    private GameController _gameController;

    [Inject]
    private void Construct(GameConfig gameConfig, GameController gameController)
    {
      _gameConfig = gameConfig;
      _gameController = gameController;

      _gameController.OnGameStarted += StartCar;
      _gameController.OnGameEnded += StopCar;
    }

    private void Awake()
    {
      _carMover = GetComponent<CarMover>();

      var carParameters = _gameConfig.CarParameters;
      _carMover.Initialize(carParameters.Speed);

      _maxHealth = carParameters.MaxHealth;
      _currentHealth = _maxHealth;
      
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
      _currentHealth -= damage;
      _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

      if (_currentHealth <= 0)
      {
        CarDestroyed();
      }
    }

    private void CarDestroyed()
    {
      _carMover.ToggleEngine(false);
      _gameController.EndGame(false);
    }
  }
}