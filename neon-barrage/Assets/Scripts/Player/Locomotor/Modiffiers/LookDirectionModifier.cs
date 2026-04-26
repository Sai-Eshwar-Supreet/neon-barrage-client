using DG.Tweening;
using UnityEngine;

public class LookDirectionModifier : BasePlayerModifier
{
    private float currentDirection = 1;
    public LookDirectionModifier(PlayerMovementContext ctx) : base(ctx)
    {
    }

    public override void Update()
    {
        float direction = Mathf.Sign(ctx.Velocity.x);

        if (currentDirection == direction || ctx.Velocity.x == 0) return;

        currentDirection = direction;

        Vector3 targetRotation = direction < 0 ? new Vector3(0, 180, 0) : Vector3.zero;

        ctx.Transform.DOKill();
        ctx.Transform.DORotate(targetRotation, 0.2f).SetEase(Ease.OutQuad);
    }
}
