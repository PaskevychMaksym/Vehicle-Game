using System;
using System.Collections;
using UnityEngine;

namespace Enemy
{
  public class EnemyVisualEffects : MonoBehaviour
  {
    [SerializeField] private Material _damagedMaterial;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private ParticleSystem _explosionEffect;

    private Material _defaultMaterial;

    private void Start()
    {
      _defaultMaterial = _renderer.material;
    }

    private void OnEnable()
    {
      _renderer.enabled = true;
    }

    public void TriggerExplosion(Action onExplosionFinished)
    {
      _explosionEffect.Play();
      StartCoroutine(WaitForExplosionToEnd(onExplosionFinished));
    }

    public void ChangeMaterial()
    {
      StartCoroutine(ChangeMaterialTemporarily());
    }

    private IEnumerator ChangeMaterialTemporarily()
    {
      _renderer.material = _damagedMaterial;
      yield return new WaitForSeconds(0.2f);
      _renderer.material = _defaultMaterial;
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
    
  }
}