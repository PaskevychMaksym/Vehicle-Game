using DefaultNamespace;

namespace Enemy.StateMachine
{
  public class ExplodeState : State<EnemyController>
  {
    public override void Enter (EnemyController owner)
    {
      owner.StateMachine.ChangeState(new DieState());
    }

    public override void Update (EnemyController owner) {}

    public override void Exit() {}
  }
}