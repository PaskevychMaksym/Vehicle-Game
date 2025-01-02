using System;
using UnityEngine;

namespace Parameters
{
    [Serializable]
    public class CarParameters
    {
        [Min(1f)]public float Speed;
        [Min(1)]public int MaxHealth;
    }
}
