using Interfaces;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Turret
{
  public class TurretRotation : MonoBehaviour
  {
    private IInputService _inputService;
    private float _rotationSpeed;
    private float _maxRotationAngle;

    private float _currentRotationY;
    private float _targetRotationY;

    [Inject]
    private void Construct(IInputService inputService, GameConfig gameConfig)
    {
      _inputService = inputService;
      _rotationSpeed = gameConfig.TurretParameters.RotationSpeed;
      _maxRotationAngle = gameConfig.TurretParameters.MaxRotationAngle;
    }

    private void Update()
    {
      if (!_inputService.IsInputActive())
        return;

      Vector2 inputDelta = _inputService.GetInputDelta();
      RotateTurret(inputDelta.x);
    }

    private void RotateTurret(float deltaX)
    {
      float rotationAmount = deltaX * _rotationSpeed * Time.deltaTime;

      _currentRotationY += rotationAmount;
      _currentRotationY = Mathf.Clamp(_currentRotationY, -_maxRotationAngle, _maxRotationAngle);

      transform.localRotation = Quaternion.Euler(0, _currentRotationY, 0);
    }
  }
}