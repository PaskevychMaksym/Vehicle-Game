using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Parameters
{
  [Serializable]
  public class EnemyParameters 
  {
    [FormerlySerializedAs("EnemyPrefab")]
    public Enemy.EnemyController EnemyControllerPrefab;
    [Min(1f)] public float DespawnDistance;
    [Min(1f)]public float Speed;
    [Min(1f)]public float RotationSpeed;
    [Min(1)]public int MaxHealth;
    [Min(1)]public int Damage;
    [Min(1)]public float ChaseDistance;
  }
}
