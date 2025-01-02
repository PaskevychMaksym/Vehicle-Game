namespace Enemy.StateMachine
{
  public class ChaseState : State<EnemyController>
  {
    public override void Enter(EnemyController owner)
    {
      owner.Animator.PlayRunAnimation();
    }

    public override void Update(EnemyController owner)
    {
      owner.EnemyMover.MoveTowards(owner.Target.transform, owner.Parameters);
    }
    
    public override void Exit() { }
  }
}