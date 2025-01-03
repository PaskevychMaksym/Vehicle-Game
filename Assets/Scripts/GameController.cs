using System;
using UI;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
  public event Action OnGameStarted;
  public event Action OnGameEnded;
  public event Action<float> OnProgressUpdated;

  private float _maxDistance;
  
  private StartMenu _startMenu;
  private ConclusionMenu _conclusionMenu;
  private Car.CarController _carController;
  private FinishLine _finishLine;

  [Inject]
  public void Construct(
    StartMenu startMenu,
    ConclusionMenu conclusionMenu,
    Car.CarController carController,
    FinishLine finishLine)
  {
    _startMenu = startMenu;
    _conclusionMenu = conclusionMenu;
    _carController = carController;
    _finishLine = finishLine;
  }

  private void Start()
  {
    _maxDistance = Vector3.Distance(_carController.transform.position, _finishLine.transform.position);
    
    _startMenu.OnStartGame += StartGame;
    _conclusionMenu.OnRestart += RestartGame;
    _carController.OnDestroyed += () => EndGame(false);
    
    _startMenu.Show();
  }

  private void OnDestroy()
  {
    _startMenu.OnStartGame -= StartGame;
    _conclusionMenu.OnRestart -= RestartGame;

    OnGameEnded = null;
    OnGameStarted = null;
  }
  
  private void Update()
  {
    float currentDistance = Vector3.Distance(_carController.transform.position, _finishLine.transform.position);
    float progress = currentDistance / _maxDistance;

    OnProgressUpdated?.Invoke(progress);
  }

  private void StartGame()
  {
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