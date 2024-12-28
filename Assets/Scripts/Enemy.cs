using UnityEngine;
using Parameters;

public class Enemy : MonoBehaviour
{
  private EnemyParameters _parameters;
  private ObjectFactory<Enemy> _factory;
  private Transform _targetTransform;

  public void Initialize(EnemyParameters parameters, Transform targetTransform, ObjectFactory<Enemy> factory)
  {
    _parameters = parameters;
    _targetTransform = targetTransform;
    _factory = factory;
    
    ResetState();
  }

  private void ResetState()
  {
    
  }

  private void Update()
  {
    if (ShouldBeReturnedToPool())
    {
      ReturnToPool();
    }
  }

  private void ReturnToPool()
  {
    _factory.ReturnObject(this);
  }

  public void Die()
  {
    ReturnToPool();
  }
  
  private bool ShouldBeReturnedToPool()
  {
    return _targetTransform != null && transform.position.z < _targetTransform.position.z - _parameters.DespawnDistance;
  }
}