using Interfaces;
using UnityEngine;

namespace InputHandler
{
  public class MouseInputProvider : IInputProvider
  {
    public Vector2 GetCurrentPosition()
    {
      return Input.mousePosition;
    }

    public bool IsActive()
    {
      return Input.GetMouseButton(0);
    }

    public bool IsBegin()
    {
      return Input.GetMouseButtonDown(0);
    }
  }
}