using UnityEngine;

public class LocomotionState : BaseState<PlayerController>
{
    public LocomotionState(PlayerController context) : base(context) { }

    public override void EnterState()
    {

    }

    public override void UpdateState()
    {
        Context.Locomotor.ApplyModifiers();
        Context.Locomotor.Move();

        CheckSwitchStates();
    }
    public override void CheckSwitchStates()
    {
        if (Context.Traverser.IsClimbPressed && Context.Traverser.IsWallAvailable) SwitchState<ClimbState>();
    }

    public override void ExitState()
    {
        Context.Locomotor.TerminateModifiers();
    }
}
