using UnityEngine;

namespace Interfaces
{
  public interface IInputService
  {
    Vector2 GetInputDelta();
    bool IsInputActive();
  }
}