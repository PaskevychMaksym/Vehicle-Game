using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  public class StartMenu : MonoBehaviour
  {
    public event Action OnStartGame;

    [SerializeField]
    private Button _startButton;

    private void Awake()
    {
      _startButton.onClick.AddListener(() =>
      {
        OnStartGame?.Invoke();
        Hide();
      });
    }

    public void Show()
    {
      gameObject.SetActive(true);
    }

    public void Hide()
    {
      gameObject.SetActive(false);
    }
  }
}