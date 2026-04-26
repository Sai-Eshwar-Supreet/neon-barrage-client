using UnityEngine;

[CreateAssetMenu(fileName = "JumpAbilityData", menuName = "Ability Data/JumpAbilityData")]
public class JumpAbilityData : ScriptableObject
{
    [SerializeField] private float jumpDuration = 0.5f;
    [SerializeField] private float maxJumpHeight = 2.5f;
    [SerializeField] private float groundStickGravity = -2f;

    public float JumpDuration => jumpDuration;
    public float MaxJumpHeight => maxJumpHeight;
    public float GroundStickGravity => groundStickGravity;
}
