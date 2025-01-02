using UnityEngine;
using Zenject;

public class FinishLine : MonoBehaviour
{
  private GameController _gameController;

  [Inject]
  public void Construct(GameController gameController)
  {
    _gameController = gameController;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.TryGetComponent<Car.Car>(out var car))
    {
      _gameController.EndGame(true);
    }
  }
}