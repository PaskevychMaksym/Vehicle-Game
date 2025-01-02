using UnityEngine;

namespace Enemy
{
  public class EnemyAnimator
  {
    private readonly Animator _animator;

    public EnemyAnimator(Animator animator)
    {
      _animator = animator;
    }

    public void PlayIdleAnimation() => PlayAnimation(Enums.EnemyAnimation.Idle);
    public void PlayRunAnimation() => PlayAnimation(Enums.EnemyAnimation.Run);
    public void PlayVictoryAnimation() => PlayAnimation(Enums.EnemyAnimation.Victory);

    private void PlayAnimation(Enums.EnemyAnimation animationType)
    {
      _animator.SetTrigger(animationType.ToString());
    }
  }
}