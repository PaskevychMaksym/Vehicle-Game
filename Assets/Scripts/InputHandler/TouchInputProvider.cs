using Interfaces;
using UnityEngine;

namespace InputHandler
{
  public class TouchInputProvider : IInputProvider
  {
    public Vector2 GetCurrentPosition()
    {
      return Input.GetTouch(0).position;
    }

    public bool IsActive()
    {
      return Input.touchCount > 0;
    }

    public bool IsBegin()
    {
      return Input.GetTouch(0).phase == TouchPhase.Began;
    }
  }
}