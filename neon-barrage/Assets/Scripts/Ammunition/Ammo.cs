using UnityEngine;

public class Ammo : PooledObject
{
    [SerializeField] private AmmoData ammoData;
    [SerializeField] private Rigidbody rigidBody;

    private Vector3 m_FireDirection = Vector3.forward;

    float m_FireInitTime = -1;

    public void Fire(Vector3 fireDirection)
    {
        m_FireDirection = fireDirection;
        rigidBody.linearVelocity = m_FireDirection * ammoData.BulletSpeed;
        m_FireInitTime = Time.time;
    }
    private void Update()
    {
        if (m_FireInitTime == -1) return;
        if (Time.time - m_FireInitTime > ammoData.LifeTime)
        {
            m_FireInitTime = -1;
            DeactivateObject();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out var dammagable))
        {
            dammagable.TakeDamage(ammoData.DamagePerHit);
        }

        Instantiate(ammoData.ImpactPS, transform.position, Quaternion.identity);

        m_FireInitTime = -1;

        DeactivateObject();
    }
    public void OnDisable()
    {
        m_FireDirection = Vector3.zero;
    }

}
