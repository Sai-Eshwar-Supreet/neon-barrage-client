using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "JumpAbilityData", menuName = "Ability Data/JumpAbilityData")]
public class JumpAbilityData : ScriptableObject
{

    [SerializeField] private float jumpDuration = 0.5f;
    [SerializeField] private float maxJumpHeight = 2.5f;
    [SerializeField] private float groundStickGravity = -2f;
    [SerializeField] private float jumpInputBufferTime = 0.2f;
    [SerializeField] private InputActionReference jumpAction;

    public float JumpDuration => jumpDuration;
    public float MaxJumpHeight => maxJumpHeight;
    public float GroundStickGravity => groundStickGravity;
    public float JumpInputBufferTime => jumpInputBufferTime;
    public InputActionReference JumpAction => jumpAction;
}
