using DefaultNamespace;
using UnityEngine;

namespace Enemy.StateMachine
{
  public class IdleState : State<EnemyController>
  {
    public override void Enter(EnemyController owner)
    {
      owner.Animator.PlayIdleAnimation();
    }

    public override void Update(EnemyController owner)
    {
      float distanceToTarget = Vector3.Distance(owner.transform.position, owner.Target.transform.position);
      if (distanceToTarget <= owner.Parameters.ChaseDistance)
      {
        owner.StateMachine.ChangeState(new ChaseState());
      }
    }
    public override void Exit() { }
  }
}
