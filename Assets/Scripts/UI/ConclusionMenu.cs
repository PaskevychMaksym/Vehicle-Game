using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  public class ConclusionMenu : MonoBehaviour
  {
    public event Action OnRestart;
    
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private Button _restartButton;

    private void Awake()
    {
      _restartButton.onClick.AddListener(() =>
      {
        OnRestart?.Invoke();
        gameObject.SetActive(false);
      });
      
      Hide();
    }

    public void Show(bool isWin)
    {
      _resultText.text = isWin ? "You Win" : "You Lose";
      gameObject.SetActive(true);
    }

    private void Hide()
    {
      gameObject.SetActive(false);
    }
  }
}
