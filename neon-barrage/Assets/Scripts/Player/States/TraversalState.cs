using UnityEngine;

public class TraversalState : BaseHierarchicalState<PlayerController>
{
    public TraversalState(PlayerController context, bool isRootState) : base(context, isRootState)
    {
    }

    public override void EnterState()
    {
        InitializeSubstates();
    }

    public override void InitializeSubstates()
    {

    }

    public override void UpdatePhysics()
    {
        // noop
    }

    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }

    public override void CheckSwitchStates()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }
}
