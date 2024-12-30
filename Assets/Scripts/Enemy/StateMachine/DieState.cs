using DefaultNamespace;

namespace Enemy.StateMachine
{
  public class DieState : State<EnemyController>
  {
    public override void Enter(EnemyController owner)
    {
      owner.HealthSlider.Hide();
      owner.EnemyVisualEffects.TriggerExplosion(() =>
      {
        owner.Health.OnDeath -= owner.HandleDeath;
        owner.Factory.ReturnObject(owner);
      });
    }

    public override void Update(EnemyController owner) { }

    public override void Exit() { }
  }
}