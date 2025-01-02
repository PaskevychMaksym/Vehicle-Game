using System;
using UI;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
  public event Action OnGameStarted;
  public event Action OnGameEnded;

  private StartMenu _startMenu;
  private ConclusionMenu _conclusionMenu;

  [Inject]
  public void Construct(
    StartMenu startMenu,
    ConclusionMenu conclusionMenu)
  {
    _startMenu = startMenu;
    _conclusionMenu = conclusionMenu;
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

    OnGameEnded = null;
    OnGameStarted = null;
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