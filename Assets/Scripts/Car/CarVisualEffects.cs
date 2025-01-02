using UnityEngine;
namespace Car
{
    public class CarVisualEffects : VisualEffects
    {
        [SerializeField] private ParticleSystem _explosionEffect;

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
    }
}
