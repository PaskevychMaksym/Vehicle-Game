using Parameters;
using UnityEngine;

//[CreateAssetMenu]
namespace ScriptableObjects
{
  public class GameConfig : ScriptableObject
  {
    [SerializeField] private CarParameters _carParameters;
    [SerializeField] private TurretParameters _turretParameters;
    [SerializeField] private BulletParameters _bulletParameters;
    [SerializeField] private EnemyParameters _enemyParameters;

    public CarParameters CarParameters => _carParameters;
    public TurretParameters TurretParameters => _turretParameters;
    public BulletParameters BulletParameters => _bulletParameters;
    public EnemyParameters EnemyParameters => _enemyParameters;
  }
}
