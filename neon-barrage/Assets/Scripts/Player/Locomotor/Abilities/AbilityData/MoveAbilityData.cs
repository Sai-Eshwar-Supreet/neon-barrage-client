using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "MoveAbilityData", menuName = "Ability Data/MoveAbilityData")]
public class MoveAbilityData : ScriptableObject
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float sprintSpeed = 12f;
    [SerializeField] private InputActionReference moveInput;
    [SerializeField] private InputActionReference sprintInput;

    public float MoveSpeed => moveSpeed;
    public float SprintSpeed => sprintSpeed;
    public InputActionReference MoveInput => moveInput;
    public InputActionReference SprintInput => sprintInput;
}
