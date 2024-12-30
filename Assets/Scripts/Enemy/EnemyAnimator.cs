using UnityEngine;

namespace Enemy
{
  public class EnemyAnimator
  {
    private enum EnemyAnimation
    {
      Idle,
      Run,
      Victory
    }
    
    private readonly Animator _animator;

    public EnemyAnimator(Animator animator)
    {
      _animator = animator;
    }

    public void PlayIdleAnimation() => PlayAnimation(EnemyAnimation.Idle);
    public void PlayRunAnimation() => PlayAnimation(EnemyAnimation.Run);
    public void PlayVictoryAnimation() => PlayAnimation(EnemyAnimation.Victory);

    private void PlayAnimation(EnemyAnimation animationType)
    {
      _animator.SetTrigger(animationType.ToString());
    }
  }
}