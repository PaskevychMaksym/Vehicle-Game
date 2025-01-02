using System;
using System.Collections;
using UnityEngine;

namespace Enemy
{
  public class EnemyVisualEffects : VisualEffects
  {
    [SerializeField] private ParticleSystem _explosionEffect;
    
    private void OnEnable()
    {
      _renderer.enabled = true;
    }
    
    public void TriggerExplosion(Action onExplosionFinished)
    {
      _explosionEffect.Play();
      StartCoroutine(WaitForExplosionToEnd(onExplosionFinished));
    }
    
    private IEnumerator WaitForExplosionToEnd(Action onExplosionFinished)
    {
      _renderer.enabled = false;

      while (_explosionEffect.isPlaying)
      {
        yield return null;
      }

      onExplosionFinished?.Invoke();
    }
    
    public override void ChangeMaterial()
    {
      StartCoroutine(ChangeMaterialTemporarily());
    }
    
    private IEnumerator ChangeMaterialTemporarily()
    {
      _renderer.material = _damagedMaterial;
      yield return new WaitForSeconds(0.2f);
      ResetMaterial();
    }
  }
}