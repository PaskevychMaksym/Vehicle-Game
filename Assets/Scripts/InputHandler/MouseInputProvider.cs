using Interfaces;
using UnityEngine;

  public class MouseInputProvider : IInputProvider
  {
    public Vector2 GetCurrentPosition()
    {
      return UnityEngine.Input.mousePosition;
    }

    public bool IsActive()
    {
      return UnityEngine.Input.GetMouseButton(0);
    }

    public bool IsBegin()
    {
      return UnityEngine.Input.GetMouseButtonDown(0);
    }
  }