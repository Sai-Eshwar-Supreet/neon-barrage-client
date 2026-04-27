using UnityEngine;

public class ClimbState : BaseState<PlayerController>
{
    public ClimbState(PlayerController context) : base(context)
    {
    }

    public override void EnterState()
    {
        // noop
    }

    public override void UpdateState()
    {
        Context.Traverser.Climb();
        CheckSwitchStates();
    }
    public override void CheckSwitchStates()
    {
        if (Context.Traverser.IsClimbPressed && !Context.Traverser.IsWallAvailable)
        {
            SwitchState<VaultState>();
            return;
        }

        if (!Context.Traverser.IsClimbPressed || !Context.Traverser.IsWallAvailable)
        {
            SwitchState<LocomotionState>();
            return;
        }
    }

    public override void ExitState()
    {
        // noop
    }

}
