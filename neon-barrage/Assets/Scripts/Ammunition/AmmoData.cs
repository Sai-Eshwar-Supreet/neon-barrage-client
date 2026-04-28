using UnityEngine;

[CreateAssetMenu(fileName = "AmmoData", menuName = "Weapons/Ammo Data")]
public class AmmoData : ScriptableObject
{
    [field: SerializeField] public ParticleSystem ImpactPS { get; private set; }
    [field: SerializeField] public float BulletSpeed { get; private set; } = 20f;
    [field: SerializeField] public float DamagePerHit { get; private set; } = 25f;
    [field: SerializeField] public float LifeTime { get; private set; } = 60f;
}
