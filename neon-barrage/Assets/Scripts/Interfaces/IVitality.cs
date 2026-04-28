public interface IVitality
{
    bool IsVulnerable { get; }
    float Health { get; }
    float MaxHealth { get; }

    void SetHealth(float health);

    bool IsAlive();
}