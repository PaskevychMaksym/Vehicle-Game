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

    [Inject]
    private void Construct(GameConfig gameConfig)
    {
      _gameConfig = gameConfig;
    }

    private void Awake()
    {
      _carMover = GetComponent<CarMover>();
      
      var carParameters = _gameConfig.CarParameters;
      _carMover.Initialize(carParameters.Speed);

      _maxHealth = carParameters.MaxHealth;
      _currentHealth = _maxHealth;
    }

    private void Start()
    {
      _carMover.ToggleEngine(true);
    }

    public void TakeDamage(int damage)
    {
      _currentHealth -= damage;
      _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

      if (_currentHealth <= 0)
      {
        OnCarDestroyed();
      }
    }

    private void OnCarDestroyed()
    {
      _carMover.ToggleEngine(false);
      Debug.Log("Car destroyed!");
    }
  }
}