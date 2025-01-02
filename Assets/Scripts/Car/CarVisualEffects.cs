using UnityEngine;

namespace Car
{
    public class CarVisualEffects : VisualEffects
    {
        [SerializeField] private ParticleSystem _explosionEffect;
        [SerializeField] private TrailRenderer [] _trailArray;

        public void TriggerExplosion()
        {
            _explosionEffect.Play();
            ChangeMaterial();
        }

        public override void ChangeMaterial()
        {
            base.ChangeMaterial();
            _renderer.enabled = true;
        }

        public void ToggleTrail (bool value)
        {
            foreach (var trail in _trailArray)
            {
                trail.enabled = value;
            }
        }
    }
}
