using UnityEngine;

public class ObjectFactory<T> where T : MonoBehaviour
{
  private readonly ObjectPool<T> _objectPool;

  public ObjectFactory(T prefab, Transform parent)
  {
    _objectPool = new ObjectPool<T>(prefab, parent);
  }

  public T CreateObject()
  {
    return _objectPool.Get();
  }

  public void ReturnObject(T obj)
  {
    _objectPool.ReturnToPool(obj);
  }
}