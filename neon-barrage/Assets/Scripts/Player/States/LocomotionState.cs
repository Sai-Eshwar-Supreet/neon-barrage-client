using UnityEngine;

public class LocomotionState : BaseHierarchicalState<PlayerController>
{
    public LocomotionState(PlayerController context, bool isRootState) : base(context, isRootState)
    {
    }

    public override void EnterState()
    {

    }
    public override void InitializeSubstates()
    {
        // no sub states
    }
    public override void UpdatePhysics()
    {
        // noop
    }

    public override void UpdateState()
    {
        Context.Locomotor.ApplyModifiers();

        CheckSwitchStates();
    }
    public override void CheckSwitchStates()
    {
        // add state transitions
    }

    public override void ExitState()
    {

    }
}
