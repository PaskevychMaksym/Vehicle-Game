using Parameters;
using UnityEngine;

namespace Enemy
{
  public class EnemyMover : MonoBehaviour
  {
    public void MoveTowards(Transform target, EnemyParameters parameters)
    {
      float speed = parameters.Speed;
      float rotationSpeed = parameters.RotationSpeed;
      
      Vector3 direction = (target.position - transform.position).normalized;
      transform.position += direction * (speed * Time.deltaTime);
      
      Quaternion lookRotation = Quaternion.LookRotation(direction);
      transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
  }
}