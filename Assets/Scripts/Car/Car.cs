using ScriptableObjects;
using UnityEngine;
namespace Car
{
  public class Car : MonoBehaviour
  {
    [SerializeField] private GameConfig gameConfig;
    private CarMover _carMover;
    private int _maxHealth;
    private int _currentHealth;

    private void Awake()
    {
      _carMover = GetComponent<CarMover>();
      
      var carParameters = gameConfig.CarParameters;
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