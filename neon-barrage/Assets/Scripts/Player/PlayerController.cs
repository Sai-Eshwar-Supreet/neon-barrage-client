using UnityEngine;

public class PlayerController : BaseStateMachine
{
    [SerializeField] private PlayerLocomotor locomotor;
    [SerializeField] private PlayerTraverser traverser;

    public PlayerLocomotor Locomotor => locomotor;
    public PlayerTraverser Traverser => traverser;
    public override void InitializeStates()
    {
        StateFactory = new StateFactory();

        StateFactory.AddState(new LocomotionState(this));
        StateFactory.AddState(new ClimbState(this));
        StateFactory.AddState(new VaultState(this));

        CurrentState = StateFactory.GetState<LocomotionState>();
    }
}
