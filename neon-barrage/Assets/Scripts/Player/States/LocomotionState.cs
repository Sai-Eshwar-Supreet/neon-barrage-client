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

        CheckSwitchStates();
    }
    public override void CheckSwitchStates()
    {
        bool triesClimbing = Context.Traverser.IsClimbPressed && Context.Traverser.IsWallAvailable;

        if (triesClimbing) SwitchState<ClimbState>();
    }

    public override void ExitState()
    {

    }
}
