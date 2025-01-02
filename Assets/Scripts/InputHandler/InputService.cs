using Interfaces;
using UnityEngine;

namespace InputHandler
{
  public class InputService : IInputService
  {
    private readonly IInputProvider _inputProvider;
    private Vector2 _previousPosition;
  
    public InputService(IInputProvider inputProvider)
    {
      _inputProvider = inputProvider;
    }

    public Vector2 GetInputDelta()
    {
      if (!_inputProvider.IsActive())
      {
        _previousPosition = Vector2.zero;
        return Vector2.zero;
      }

      Vector2 currentPosition = _inputProvider.GetCurrentPosition();

      if (_inputProvider.IsBegin() || _previousPosition == Vector2.zero)
      {
        _previousPosition = currentPosition;
        return Vector2.zero;
      }

      Vector2 delta = currentPosition - _previousPosition;
      _previousPosition = currentPosition;
      return delta;
    }

    public bool IsInputActive()
    {
      return _inputProvider.IsActive();
    }
  }
}