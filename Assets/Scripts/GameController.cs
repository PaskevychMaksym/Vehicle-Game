using System;
using UI;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
  public event Action OnGameStarted;
  public event Action OnGameEnded;
  
  private CamerasController _cameraController;
  private StartMenu _startMenu;
  private ConclusionMenu _conclusionMenu;
  private Car.Car _car;

  [Inject]
  public void Construct(CamerasController cameraController, 
    StartMenu startMenu,
    ConclusionMenu conclusionMenu,
    Car.Car car)
  {
    _cameraController = cameraController;
    _startMenu = startMenu;
    _conclusionMenu = conclusionMenu;
    _car = car;
  }

  private void Start()
  {
    _startMenu.OnStartGame += StartGame;
    _conclusionMenu.OnRestart += RestartGame;
    
    _startMenu.Show();
  }

  private void OnDestroy()
  {
    _startMenu.OnStartGame -= StartGame;
    _conclusionMenu.OnRestart -= RestartGame;
  }

  private void StartGame()
  {
    _car.StartCar();
    OnGameStarted?.Invoke();
  }

  public void EndGame(bool isWin)
  {
    _conclusionMenu.Show(isWin);
    OnGameEnded?.Invoke();
  }

  private void RestartGame()
  {
    UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
  }
}