using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Parameters
{
    [Serializable]
    public class CarParameters
    {
        public Car.CarController CarPrefab;
        [Min(1f)]public float Speed;
        [Min(1)]public int MaxHealth;
    }
}
