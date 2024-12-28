using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Parameters
{
  [Serializable]
  public class EnemiesSpawnParameters
  {
    [Min(1)] public int StartAmount;
    [Min(0.1f)] public float Interval;
    [Min(1f)]public float RangeX;
    [Min(1f)]public float Distance;
  }
}