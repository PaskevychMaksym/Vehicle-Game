using Parameters;
using UnityEngine;
using DefaultNamespace;
using Enemy.StateMachine;

namespace Enemy
{
  public class EnemyController : MonoBehaviour
  {
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private EnemyVisualEffects _enemyVisualEffects;
    [SerializeField] private Collider _collider;
    [SerializeField] private HealthSlider _healthSlider;

    private StateMachine<EnemyController> _stateMachine;
    private EnemyAnimator _animator;
    private Health _health;

    private EnemyParameters _parameters;
    private ObjectFactory<EnemyController> _factory;
    private Car.CarController _target;

    public EnemyParameters Parameters => _parameters;
    public Car.CarController Target => _target;
    public Health Health => _health;
    public HealthSlider HealthSlider => _healthSlider;
    public EnemyAnimator Animator => _animator;
    public EnemyMover EnemyMover => _enemyMover;
    public StateMachine<EnemyController> StateMachine => _stateMachine;
    public ObjectFactory<EnemyController> Factory => _factory;
    public EnemyVisualEffects EnemyVisualEffects => _enemyVisualEffects;

    public void Initialize (EnemyParameters parameters,
      Car.CarController target,
      ObjectFactory<EnemyController> factory,
      Transform followCameraTransform)
    {
      _parameters = parameters;
      _target = target;
      _factory = factory;
      _collider.enabled = true;

      _animator = new EnemyAnimator(_enemyAnimator);
      _stateMachine = new StateMachine<EnemyController>(this);

      _health = new Health(_parameters.MaxHealth);
      _health.OnDeath += HandleDeath;

      _healthSlider.Initialize(_health, followCameraTransform);

      _target.Health.OnDeath += () => _stateMachine.ChangeState(new VictoryState());

      _stateMachine.ChangeState(new IdleState());
    }

    public void HandleDeath()
    {
      _collider.enabled = false;
      _stateMachine.ChangeState(new DieState());
    }

    private void Update()
    {
      _stateMachine.Update();

      if (ShouldBeReturnedToPool())
      {
        _stateMachine.ChangeState(new DespawnState());
      }
    }

    private void OnTriggerEnter (Collider other)
    {
      if (other.transform != _target.transform)
      {
        return;
      }

      _target.TakeDamage(_parameters.Damage);
      _stateMachine.ChangeState(new DieState());
    }

    private bool ShouldBeReturnedToPool() => _target != null && transform.position.z < _target.transform.position.z - _parameters.DespawnDistance;

    public void TakeDamage (int damage)
    {
      _enemyVisualEffects.ChangeMaterial();
      _health.TakeDamage(damage);
      _healthSlider.UpdateSlider();
    }
  }
}