using System;
using UnityEngine;

namespace Parameters
{
  [Serializable]
  public class EnemiesSpawnParameters
  {
    [Min(0.1f)] public float Interval;
    [Min(1f)]public float RangeX;
    [Min(1f)]public float Distance;
  }
}