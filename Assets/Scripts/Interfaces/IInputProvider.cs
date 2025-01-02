using UnityEngine;

namespace Interfaces
{
  public interface IInputProvider
  {
    Vector2 GetCurrentPosition();
    bool IsActive();
    bool IsBegin();
  }
}