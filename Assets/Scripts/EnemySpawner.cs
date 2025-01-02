using System.Collections;
using Parameters;
using ScriptableObjects;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
  private const float PROGRESS_THRESHOLD = 0.2f;
  
  private float _maxDistanceToFinish;
  private Transform _followCameraTransform;
  private bool _isGameRunning;
  
  private ObjectFactory<Enemy.EnemyController> _enemyFactory;
  private EnemyParameters _enemyParameters;
  private EnemiesSpawnParameters _spawnParameters;
  private Car.CarController _target;

  [Inject]
  private void Construct(
    ObjectFactory<Enemy.EnemyController> enemyFactory,
    GameConfig gameConfig,
    Car.CarController target,
    GameController gameController,
    CamerasController camerasController)
  {
    _enemyFactory = enemyFactory;
    _enemyParameters = gameConfig.EnemyParameters;
    _spawnParameters = gameConfig.EnemiesSpawnParameters;
    _target = target;
    _followCameraTransform = camerasController.GetCamera(Enums.CameraType.Follow).transform;
    
    gameController.OnGameStarted += StartSpawning;
    gameController.OnGameEnded += StopSpawning;
    gameController.OnProgressUpdated += HandleProgressUpdated;
  }

  private void StartSpawning()
  {
    _isGameRunning = true;
    StartCoroutine(SpawnEnemiesRoutine());
  }
  
  private IEnumerator SpawnEnemiesRoutine()
  {
    while (_isGameRunning)
    {
      yield return new WaitForSeconds(_spawnParameters.Interval);
      
      SpawnEnemy();
    }
  }
  
  private void HandleProgressUpdated(float progress)
  {
    if (progress < PROGRESS_THRESHOLD)
    {
      StopSpawning();
    }
  }
  
  private void SpawnEnemy()
  {
    Vector3 spawnPosition = GetRandomSpawnPosition();
    Quaternion spawnRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
    Enemy.EnemyController enemyController = _enemyFactory.CreateObject();
    enemyController.transform.position = spawnPosition;
    enemyController.transform.rotation = spawnRotation;

    enemyController.Initialize(_enemyParameters, _target, _enemyFactory,_followCameraTransform);
  }
  
  private Vector3 GetRandomSpawnPosition()
  {
    Vector3 spawnPosition = _target.transform.position + _target.transform.forward * _spawnParameters.Distance;
    spawnPosition.x += Random.Range(-_spawnParameters.RangeX, _spawnParameters.RangeX);
    spawnPosition.y = 0;
    return spawnPosition;
  }

  private void StopSpawning()
  {
    _isGameRunning = false;
  }
}
