using UnityEngine;


[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [field: SerializeField] public bool IsInfinite { get; private set; }
    [field: SerializeField] public Ammo BulletPrefab { get; private set; }
    [field: SerializeField] public float TimeBetweenShots { get; private set; } = 0.05f;
    [field: SerializeField] public float ReloadTime { get; private set; } = 0.5f;
    [field: SerializeField, Min(1)] public int MagazineSize { get; private set; } = 20;
}
