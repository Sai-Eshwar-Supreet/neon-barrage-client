using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : BaseHealthSystem
{
    [SerializeField] private GameObject m_EnemyBehavior;

    private Collider[] m_Colliders;
    public bool IsSpawnable = false;

    protected override void Awake()
    {
        base.Awake();
        m_Colliders = GetComponents<Collider>();
    }
    private void OnEnable()
    {
        foreach (Collider collider in m_Colliders) collider.enabled = true;

        m_EnemyBehavior.SetActive(true);
    }
    protected override void Die()
    {
        base.Die();

        if (!IsSpawnable)
        {
            m_EnemyBehavior.SetActive(false);
            foreach (Collider collider in m_Colliders) collider.enabled = false;
        }
    }
}
