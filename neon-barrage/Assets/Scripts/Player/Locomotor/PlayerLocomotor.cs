using UnityEngine;
using System.Collections.Generic;

public class PlayerLocomotor : MonoBehaviour
{
    [SerializeField] private PlayerMovementInput inputProvider;
    [Header("Abilities")]
    [SerializeField] MoveAbilityData moveAbilityData;
    [SerializeField] JumpAbilityData jumpAbilityData;
    [SerializeField] DashAbilityData dashAbilityData;

    [Header("Controllers")]
    [SerializeField] CharacterController characterController;

    private PlayerMovementContext movementContext;

    private List<BasePlayerModifier> modifiers;

    private void Awake()
    {
        movementContext = new PlayerMovementContext(characterController, inputProvider);

        modifiers = new()
        {
            new HorizontalMoveModifier(movementContext, moveAbilityData),
            new JumpModifier(movementContext, jumpAbilityData),
            new DashModifier(movementContext, dashAbilityData, this),
            new LookDirectionModifier(movementContext),
        };

    }

    public void ApplyModifiers()
    {
        foreach( var  modifier in modifiers)
        {
            modifier.Update();
        }

        characterController.Move(movementContext.Velocity * Time.deltaTime);
    }
}
