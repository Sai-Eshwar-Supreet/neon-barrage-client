using UnityEngine;
using UnityEngine.InputSystem;

public class HorizontalMoveModifier : BasePlayerModifier
{
    private readonly MoveAbilityData data;

    public HorizontalMoveModifier(PlayerMovementContext ctx, MoveAbilityData data) :  base(ctx)
    {
        this.data = data;
    }

    public override void Update()
    {
        float currentSpeed = ctx.Input.IsSprintPressed ? data.SprintSpeed : data.MoveSpeed;
        float movementX = ctx.Input.HorizontalMove;
        ctx.Velocity.x = currentSpeed * movementX;
    }
}
