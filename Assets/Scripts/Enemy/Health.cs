using System;
public class Health
{
  public event Action OnDeath;
  public int CurrentHealth { get; private set; }

  public Health(int maxHealth)
  {
    CurrentHealth = maxHealth;
  }

  public void TakeDamage(int damage)
  {
    CurrentHealth -= damage;
    if (CurrentHealth <= 0)
    {
      OnDeath?.Invoke();
    }
  }
}