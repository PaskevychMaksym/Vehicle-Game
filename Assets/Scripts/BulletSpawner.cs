using ScriptableObjects;
using UnityEngine;
using Zenject;

public class BulletSpawner
{
  private readonly ObjectFactory<Bullet> _bulletFactory;
  private readonly GameConfig _gameConfig;

  [Inject]
  public BulletSpawner(GameConfig gameConfig, ObjectFactory<Bullet> bulletFactory)
  {
    _gameConfig = gameConfig;
    _bulletFactory = bulletFactory;
  }

  public void FireBullet(Vector3 position, Quaternion rotation)
  {
    Bullet bullet = _bulletFactory.CreateObject();
    bullet.transform.position = position;
    bullet.transform.rotation = rotation;
    bullet.Initialize(_gameConfig.BulletParameters, _bulletFactory);
    bullet.Launch(_gameConfig.BulletParameters);
    bullet.gameObject.SetActive(true);
  }
}