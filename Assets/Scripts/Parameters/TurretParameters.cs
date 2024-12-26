using System;
using UnityEngine;

namespace Parameters
{
  [Serializable]
  public class TurretParameters
  {
    [Min(0.1f)]public float RotationSpeed;
    [Min(10f)]public float MaxRotationAngle;
    [Min(0.1f)]public float FireRate; 
  }
}
