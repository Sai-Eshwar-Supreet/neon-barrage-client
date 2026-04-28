using UnityEngine;
using UnityEngine.Events;

public abstract class BaseHealthSystem : MonoBehaviour, IVitality, IDamageable, IHealable
{
    public event System.Action OnDie;
    public event System.Action<float> OnHealthChange;
    public event System.Action OnHeal;
    public event System.Action OnTakeDamage;
    public event System.Action OnUpgrade;
    [field: SerializeField] public bool IsVulnerable { get; set; } = true;

    [field: SerializeField] public float MaxHealth { get; private set; } = 100;
    public float Health { get; private set; }

    protected virtual void Awake()
    {
        Health = MaxHealth;
    }

    public virtual void TakeDamage(float amount)
    {
        if (!IsVulnerable) return;
        OnTakeDamage?.Invoke();
        SetHealth(Health - amount);

    }
    public void UpgradeHealthSystem()
    {
        MaxHealth += 50;
        OnUpgrade?.Invoke();
    }
    public virtual void SetHealth(float health)
    {
        Health = health;
        OnHealthChange?.Invoke(health);
        if (!IsAlive())
        {
            Die();
        }
    }

    public virtual void Heal(float amount)
    {
        OnHeal?.Invoke();
        SetHealth(Mathf.Min(Health + amount, MaxHealth));
    }

    protected virtual void Die()
    {
        OnDie?.Invoke();
    }

    public bool IsAlive()
    {
        return Health > 0;
    }
}
