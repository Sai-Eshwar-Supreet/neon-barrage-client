using System;

public abstract class BaseState<S> : IState where S : BaseStateMachine
{
    public BaseState(S context) => Context = context;

    public readonly S Context;

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void UpdatePhysics();
    public abstract void CheckSwitchStates();
    public abstract void ExitState();

    public void SwitchState<T>() where T : IState
    {
        var newState = Context.StateFactory.GetState<T>() ?? throw new InvalidOperationException($"Cannot switch to state {typeof(T).Name} as it's not a valid BaseHState<{typeof(S).Name}>");
        
        ExitState();

        Context.CurrentState = newState;
        Context.CurrentState.EnterState();
    }

}
