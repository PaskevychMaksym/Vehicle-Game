namespace Interfaces
{
  public interface IDamageable
  {
    public int CurrentHealth { get; }
    public void TakeDamage(int damage);
    public void Die();
  }
}
