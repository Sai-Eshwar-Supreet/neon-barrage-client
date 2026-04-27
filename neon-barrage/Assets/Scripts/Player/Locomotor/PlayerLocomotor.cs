using UnityEngine;
using System.Collections.Generic;

public class PlayerLocomotor : MonoBehaviour
{
    [SerializeField] private PlayerMovementInput inputProvider;
    [SerializeField] private PlayerStats playerStats;

    [Header("Controllers")]
    [SerializeField] private CharacterController characterController;

    private PlayerMovementContext movementContext;

    private List<BasePlayerModifier<PlayerMovementContext>> modifiers;

    private void Awake()
    {
        movementContext = new PlayerMovementContext(characterController, inputProvider, playerStats);

        modifiers = new()
        {
            new HorizontalMoveModifier(movementContext),
            new JumpModifier(movementContext),
            new DashModifier(movementContext),
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
