using UnityEngine;

public class CarMover : MonoBehaviour
{
  private Rigidbody _carRigidbody; 
  private float _acceleration;
  private bool _isMoving;

  public void Initialize(float speed)
  {
    _carRigidbody = GetComponent<Rigidbody>();
    _acceleration = speed;
  }

  public void ToggleEngine(bool value)
  {
    _isMoving = value;

    if (!_isMoving)
    {
      _carRigidbody.velocity = Vector3.zero;
    }
  }

  private void FixedUpdate()
  {
    if (_isMoving && _carRigidbody != null)
    {
      _carRigidbody.velocity = transform.forward * _acceleration;
    }
  }
}
