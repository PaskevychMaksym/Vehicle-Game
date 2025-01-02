using UnityEngine;
namespace Bullet
{
  public class BulletVisualEffects : MonoBehaviour
  {
    [SerializeField] private TrailRenderer _trailRenderer;

    public void ToggleTrail (bool value)
    {
      _trailRenderer.enabled = value;
    }
  }
}
