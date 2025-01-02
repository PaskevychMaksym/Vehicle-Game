using Parameters;
using UnityEngine;
namespace Bullet
{
  public class Bullet : MonoBehaviour
  {
    [SerializeField]
    private BulletVisualEffects _visualEffects;
    
    private float _speed;
    private int _damage;
    private float _lifeTime;
    private float _lifeTimer;
    private ObjectFactory<Bullet> _factory;

    public void Initialize(BulletParameters parameters, ObjectFactory<Bullet> factory)
    {
      _lifeTime = parameters.LifeTime;
      _damage = parameters.Damage;
      _factory = factory;
      _lifeTimer = 0f;
    }

    public void Launch(BulletParameters parameters)
    {
      _speed = parameters.Speed;
      _visualEffects.ToggleTrail(true);
      GetComponent<Rigidbody>().velocity = transform.forward * _speed;
    }

    private void Update()
    {
      _lifeTimer += Time.deltaTime;

      if (_lifeTimer >= _lifeTime)
      {
        ReturnToPool();
      }
    }

    private void ReturnToPool()
    {
      _factory.ReturnObject(this);
      _lifeTimer = 0f;
      _visualEffects.ToggleTrail(false);
      gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out Enemy.EnemyController enemy))
      {
        enemy.TakeDamage(_damage);
      }
    
      ReturnToPool();
    }
  }
}