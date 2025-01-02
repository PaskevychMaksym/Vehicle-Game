namespace Enemy.StateMachine
{
  public class DespawnState : State<EnemyController>
  {
    public override void Enter(EnemyController owner)
    {
      owner.Health.OnDeath -= owner.HandleDeath;
      owner.Factory.ReturnObject(owner);
    }

    public override void Update(EnemyController owner) {}
    public override void Exit() {}
  }
}