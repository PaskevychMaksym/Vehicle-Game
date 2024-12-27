using UnityEngine;

public class Bullet : MonoBehaviour
{
  private float _speed;
  private float _lifeTime;
  private float _lifeTimer;
  private BulletFactory _factory;

  public void Initialize(float lifeTime, BulletFactory factory)
  {
    _lifeTime = lifeTime;
    _factory = factory;
    _lifeTimer = 0f;
  }

  public void Launch(float speed)
  {
    _speed = speed;
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
    _factory.ReturnBullet(this);
    _lifeTimer = 0f;
    gameObject.SetActive(false);
  }

  private void OnCollisionEnter(Collision collision)
  {
    ReturnToPool();
  }
}