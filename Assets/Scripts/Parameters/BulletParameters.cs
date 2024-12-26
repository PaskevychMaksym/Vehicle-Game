using System;
using DefaultNamespace;
using UnityEngine;

namespace Parameters
{
  [Serializable]
  public class BulletParameters
  {
    public Bullet BulletPrefab;
    [Min(0.1f)]public float Speed;
    [Min(1)] public int Damage;
    [Min(0.1f)]public float LifeTime;
  }
}
