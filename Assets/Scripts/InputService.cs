using Interfaces;
using UnityEngine;

public class InputService : IInputService
{
  private Vector2 _previousPosition;

  public Vector2 GetInputDelta()
  {
    Vector2 currentPosition;

    if (Input.touchCount > 0)
    {
      Touch touch = Input.GetTouch(0);
      currentPosition = touch.position;
    } else if (Input.GetMouseButton(0))
    {
      currentPosition = Input.mousePosition;
    } else
    {
      _previousPosition = Vector2.zero;
      return Vector2.zero;
    }

    Vector2 delta = currentPosition - _previousPosition;
    _previousPosition = currentPosition;

    return delta;
  }

  public bool IsInputActive()
  {
    return Input.touchCount > 0 || Input.GetMouseButton(0);
  }
}