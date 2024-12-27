using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class ObjectPool<T> : IObjectPool<T> where T : MonoBehaviour
{
  private readonly Queue<T> _pool = new Queue<T>();
  private readonly T _prefab;
  private readonly Transform _parent;

  public ObjectPool(T prefab, Transform parent = null, int initialCapacity = 10)
  {
    _prefab = prefab;
    _parent = parent;

    for (int i = 0; i < initialCapacity; i++)
    {
      T obj = Object.Instantiate(_prefab, _parent);
      obj.gameObject.SetActive(false);
      _pool.Enqueue(obj);
    }
  }

  public T Get()
  {
    if (_pool.Count == 0)
    {
      T obj = Object.Instantiate(_prefab, _parent);
      obj.gameObject.SetActive(false);
      return obj;
    }

    T pooledObject = _pool.Dequeue();
    pooledObject.gameObject.SetActive(true);
    return pooledObject;
  }

  public void ReturnToPool(T obj)
  {
    obj.gameObject.SetActive(false);
    _pool.Enqueue(obj);
  }
}