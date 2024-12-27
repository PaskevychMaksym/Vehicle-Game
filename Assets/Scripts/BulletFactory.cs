using ScriptableObjects;
using UnityEngine;

public class BulletFactory
{
  private readonly ObjectPool<Bullet> _bulletPool;

  public BulletFactory(GameConfig gameConfig, Transform parent)
  {
    _bulletPool = new ObjectPool<Bullet>(gameConfig.BulletParameters.BulletPrefab, parent);
  }

  public Bullet CreateBullet()
  {
    return _bulletPool.Get();
  }

  public void ReturnBullet(Bullet bullet)
  {
    _bulletPool.ReturnToPool(bullet);
  }
}