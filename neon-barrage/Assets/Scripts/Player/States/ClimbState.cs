using UnityEngine;

public class ClimbState : BaseState<PlayerController>
{
    public ClimbState(PlayerController context) : base(context)
    {
    }

    private bool enteredWithWall = false;

    public override void EnterState()
    {
        enteredWithWall = Context.Traverser.IsWallAvailable;
    }

    public override void UpdateState()
    {
        Context.Traverser.Climb();
        CheckSwitchStates();
    }
    public override void CheckSwitchStates()
    {
        if (enteredWithWall && Context.Traverser.IsClimbPressed && !Context.Traverser.IsWallAvailable)
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
        Context.Traverser.TerminateModifiers();
        enteredWithWall = false;
    }

}
