using ScriptableObjects;
using UnityEngine;
using Zenject;

public class BulletSpawner
{
  private readonly BulletFactory _bulletFactory;
  private readonly GameConfig _gameConfig;

  [Inject]
  public BulletSpawner(GameConfig gameConfig, BulletFactory bulletFactory)
  {
    _gameConfig = gameConfig;
    _bulletFactory = bulletFactory;
  }

  public void FireBullet(Vector3 position, Quaternion rotation)
  {
    Bullet bullet = _bulletFactory.CreateBullet();
    bullet.transform.position = position;
    bullet.transform.rotation = rotation;
    bullet.Initialize(_gameConfig.BulletParameters.LifeTime, _bulletFactory);
    bullet.Launch(_gameConfig.BulletParameters.Speed);
    bullet.gameObject.SetActive(true);
  }
}