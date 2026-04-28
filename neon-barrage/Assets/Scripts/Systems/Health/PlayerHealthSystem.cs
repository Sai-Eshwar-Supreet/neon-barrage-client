using System.Collections;
using UnityEngine;

public class PlayerHealthSystem : BaseHealthSystem
{
    [SerializeField] private float selfHealAmount = 10;
    [SerializeField] private float selfHealDelay = 20;
    private float m_LastDamageTime;
    private bool m_IsSelfHealing = false;
    private WaitForSeconds m_HealingDelay;

    protected override void Awake()
    {
        base.Awake();
        m_HealingDelay = new WaitForSeconds(selfHealDelay / 2f);
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        m_LastDamageTime = Time.time;
    }

    private void Update()
    {
        if (m_IsSelfHealing || Health >= MaxHealth) return;
        if ((Time.time - m_LastDamageTime) > 30)
        {
            m_IsSelfHealing = true;
            StartCoroutine(HealAsync());
        }
    }

    private IEnumerator HealAsync()
    {
        yield return m_HealingDelay;
        SetHealth(Mathf.Min(Health + selfHealAmount, MaxHealth));
        yield return m_HealingDelay;
        m_IsSelfHealing = false;
    }
}
