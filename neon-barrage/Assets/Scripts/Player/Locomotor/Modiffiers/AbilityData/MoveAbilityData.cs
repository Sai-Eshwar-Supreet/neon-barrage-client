using UnityEngine;

[CreateAssetMenu(fileName = "MoveAbilityData", menuName = "Ability Data/MoveAbilityData")]
public class MoveAbilityData : ScriptableObject
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float sprintSpeed = 12f;

    public float MoveSpeed => moveSpeed;
    public float SprintSpeed => sprintSpeed;
}
