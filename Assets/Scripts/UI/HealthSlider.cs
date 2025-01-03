using UnityEngine;
using UnityEngine.UI;
namespace UI
{
  public class HealthSlider: MonoBehaviour
  {
    [SerializeField]
    private Slider _slider;

    private Transform _lookTarget;
    private Health _health;

    public void Initialize (Health health, Transform followCamera)
    {
      _health = health;
      _lookTarget = followCamera.transform;

      _slider.maxValue = _health.CurrentHealth;
      _slider.value = _health.CurrentHealth;

      _health.OnDeath += Hide;
      Show();
    }

    private void Awake()
    {
      Hide();
    }

    public void LateUpdate()
    {
      transform.LookAt(_lookTarget);
    }

    private void Show()
    {
      _slider.gameObject.SetActive(true);
      UpdateSlider();
    }

    public void Hide()
    {
      _slider.gameObject.SetActive(false);
    }

    public void UpdateSlider ()
    {
      _slider.value = _health.CurrentHealth;
    }
  }
}