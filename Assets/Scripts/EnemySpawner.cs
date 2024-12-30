using System.Collections;
using Parameters;
using ScriptableObjects;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
  private float _maxDistanceToFinish;
  
  private ObjectFactory<Enemy.EnemyController> _enemyFactory;
  private Car.Car _target;
  private Transform _finishTransform;
  private EnemyParameters _enemyParameters;
  private EnemiesSpawnParameters _spawnParameters;

  [Inject]
  private void Construct(
    ObjectFactory<Enemy.EnemyController> enemyFactory,
    Car.Car target, 
    Transform finishTransform,
    GameConfig gameConfig)
  {
    _enemyFactory = enemyFactory;
    _target = target;
    _finishTransform = finishTransform;
    _enemyParameters = gameConfig.EnemyParameters;
    _spawnParameters = gameConfig.EnemiesSpawnParameters;
  }

  private void Start()
  {
    _maxDistanceToFinish = Vector3.Distance(_target.transform.position, _finishTransform.position);
    SpawnInitialEnemies();
    StartCoroutine(SpawnEnemiesRoutine());
  }

  private void SpawnInitialEnemies()
  {
    for (int i = 0; i < _spawnParameters.StartAmount; i++)
    {
      SpawnEnemy();
    }
  }
  
  private IEnumerator SpawnEnemiesRoutine()
  {
    while (CalculateProgress() > 0.2f)
    {
      yield return new WaitForSeconds(_spawnParameters.Interval);
      
      SpawnEnemy();
    }
  }
  
  private void SpawnEnemy()
  {
    Vector3 spawnPosition = GetRandomSpawnPosition();
    Quaternion spawnRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
    Enemy.EnemyController enemyController = _enemyFactory.CreateObject();
    enemyController.transform.position = spawnPosition;
    enemyController.transform.rotation = spawnRotation;

    enemyController.Initialize(_enemyParameters, _target, _enemyFactory);
  }
  
  private Vector3 GetRandomSpawnPosition()
  {
    Vector3 spawnPosition = _target.transform.position + _target.transform.forward * _spawnParameters.Distance;
    spawnPosition.x += Random.Range(-_spawnParameters.RangeX, _spawnParameters.RangeX);
    spawnPosition.y = 0;
    return spawnPosition;
  }
  
  private float CalculateProgress()
  {
    float currentDistance = Vector3.Distance(_target.transform.position, _finishTransform.position);
    return currentDistance / _maxDistanceToFinish;
  }
}
