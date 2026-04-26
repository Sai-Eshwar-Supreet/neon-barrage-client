using UnityEngine;

public class PlayerController : BaseStateMachine
{
    [SerializeField] private PlayerLocomotor locomotor;

    public PlayerLocomotor Locomotor => locomotor;
    public override void InitializeStates()
    {
        StateFactory = new StateFactory();

        StateFactory.AddState(new LocomotionState(this, true));

        CurrentState = StateFactory.GetState<LocomotionState>();
    }
}
