using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Turret
{
  public class Turret : MonoBehaviour
  {
    [SerializeField] private Transform _spawnPoint;

    private BulletSpawner _bulletSpawner;
    private float _fireRate;
    private float _fireTimer;

    [Inject]
    private void Construct(BulletSpawner bulletSpawner, GameConfig gameConfig)
    {
      _bulletSpawner = bulletSpawner;
      _fireRate = gameConfig.TurretParameters.FireRate;
    }

    private void Update()
    {
      _fireTimer += Time.deltaTime;
      if (!(_fireTimer >= _fireRate))
      {
        return;
      }

      Fire();
      _fireTimer = 0f;
    }

    private void Fire()
    {
      _bulletSpawner.FireBullet(_spawnPoint.position, _spawnPoint.rotation);
    }
  }
}