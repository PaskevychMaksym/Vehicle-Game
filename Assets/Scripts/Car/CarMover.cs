using System.Collections;
using System.Collections.Generic;
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
  }

  private void FixedUpdate()
  {
    if (_isMoving && _carRigidbody != null)
    {
      _carRigidbody.AddForce(transform.forward * _acceleration, ForceMode.Acceleration);
    }
  }
}
