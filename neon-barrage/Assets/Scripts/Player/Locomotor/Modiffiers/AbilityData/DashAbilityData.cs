using UnityEngine;

[CreateAssetMenu(fileName = "DashAbilityData", menuName = "Ability Data/DashAbilityData")]
public class DashAbilityData : ScriptableObject
{
    [SerializeField] private float dashDuration = 0.25f;
    [SerializeField] private float dashCooldown = 1f;
    [SerializeField] private float dashSpeed = 20f;

    public float DashDuration => dashDuration;
    public float DashCooldown => dashCooldown;
    public float DashSpeed => dashSpeed;
}
