namespace Enemy.StateMachine
{
  public class VictoryState : State<EnemyController>
  {
    public override void Enter(EnemyController owner)
    {
      owner.Animator.PlayVictoryAnimation();
    }

    public override void Update (EnemyController owner) {}

    public override void Exit() {}
  }
}