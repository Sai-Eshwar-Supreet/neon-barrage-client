using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [Header("Horizontal Locomotion")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float dashDuration = 0.25f;
    [SerializeField] private float dashCooldown = 1f;
    [SerializeField] private float dashSpeed = 40f;

    [Header("Vertical Locomotion")]
    [SerializeField] private float jumpDuration = 0.5f;
    [SerializeField] private float maxJumpHeight = 2.5f;
    [SerializeField] private float groundStickGravity = -2f;
    [SerializeField] private float climbSpeed = 1f;
    [SerializeField] private float vaultDuration = 1f;

    public float MoveSpeed => moveSpeed;
    public float JumpDuration => jumpDuration;
    public float MaxJumpHeight => maxJumpHeight;
    public float GroundStickGravity => groundStickGravity;
    public float DashDuration => dashDuration;
    public float DashCooldown => dashCooldown;
    public float DashSpeed => dashSpeed;
    public float ClimbSpeed => climbSpeed;
    public float VaultDuration => vaultDuration;
}
