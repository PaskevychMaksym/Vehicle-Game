using UnityEngine;

public abstract class VisualEffects : MonoBehaviour
{
  [SerializeField] protected Material _damagedMaterial;
  [SerializeField] protected Renderer _renderer;

  private Material _defaultMaterial;

  protected virtual void Start()
  {
    _defaultMaterial = _renderer.material;
  }

  public virtual void ChangeMaterial()
  {
    _renderer.material = _damagedMaterial;
  }

  protected void ResetMaterial()
  {
    _renderer.material = _defaultMaterial;
  }
}