using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Turret
{
  public class Turret : MonoBehaviour
  {
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private TurretVisualEffects _turretVisualEffects;

    private BulletSpawner _bulletSpawner;
    private float _fireRate;
    private float _fireTimer;
    private bool _isActive;

    [Inject]
    private void Construct(BulletSpawner bulletSpawner, 
      GameConfig gameConfig,
      GameController gameController,
      Car.CarController carController)
    {
      _bulletSpawner = bulletSpawner;
      _fireRate = gameConfig.TurretParameters.FireRate;
      
      gameController.OnGameStarted += ActivateTurret;
      gameController.OnGameEnded += DeactivateTurret;
      carController.OnDestroyed += () => _turretVisualEffects.ChangeMaterial();
    }

    private void Update()
    {
      if (!_isActive)
        return;

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
    
    private void ActivateTurret()
    {
      _isActive = true;
    }

    private void DeactivateTurret()
    {
      _isActive = false;
    }
  }
}