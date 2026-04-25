using UnityEngine;

public class PlayerLocomotor : MonoBehaviour
{
    [Header("Abilities")]
    [SerializeField] MoveAbilityData moveAbilityData;
    [SerializeField] JumpAbilityData jumpAbilityData;
    [SerializeField] DashAbilityData dashAbilityData;

    [Header("Controllers")]
    [SerializeField] CharacterController characterController;


    private MoveAbility moveAbility;
    private JumpAbility jumpAbility;
    private DashAbility dashAbility;

    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        moveAbility = new (moveAbilityData);
        jumpAbility = new (jumpAbilityData);
        dashAbility = new (dashAbilityData);
    }

    private void OnEnable()
    {
        moveAbility.Enable();
        jumpAbility.Enable();
        dashAbility.Enable();
    }

    private void OnDisable()
    {
        moveAbility.Disable();
        jumpAbility.Disable();
        dashAbility.Disble();
    }

    private void Update()
    {
        moveAbility.Apply(ref velocity);
        jumpAbility.Apply(ref velocity, characterController.isGrounded);
        dashAbility.Apply(ref velocity, this);

        characterController.Move(velocity * Time.deltaTime);
    }
}
