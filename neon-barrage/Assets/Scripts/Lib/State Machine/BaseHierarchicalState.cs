using System;

public abstract class BaseHierarchicalState<S> : IState where S : BaseStateMachine
{
    public readonly S Context;
    public BaseHierarchicalState(S context, bool isRootState)
    {
        Context = context;
        IsRootState = isRootState;

    }

    public readonly bool IsRootState;
    public BaseHierarchicalState<S> CurrentSubState { get; private set; }
    public BaseHierarchicalState<S> CurrentSuperState { get; private set; }
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void UpdatePhysics();
    public abstract void CheckSwitchStates();

    /// <summary>
    /// Initialze all the possible substates for the corresponding state.
    /// </summary>
    public abstract void InitializeSubstates();
    public abstract void ExitState();


    public void SwitchState<T>() where T : IState
    {
        BaseHierarchicalState<S> newState = Context.StateFactory.GetState<T>() as BaseHierarchicalState<S> ?? throw new InvalidOperationException($"Cannot switch to state {typeof(T).Name} as it's not a valid BaseHState<{typeof(S).Name}>");
        
        ExitStates();

        var superState = CurrentSuperState;

        newState.EnterState();

        if (newState.IsRootState) Context.CurrentState = newState;
        else if (superState != null) superState.SetSubState(newState);
        else throw new InvalidOperationException($"Cannot set non-root state {typeof(T).Name} without a super state");
    }



    //substate functions

    /// <summary>
    /// Calls the update function of the respective state and it's sub states.
    /// </summary>
    public void UpdateStates()
    {
        UpdateState();
        CurrentSubState?.UpdateStates();
    }
    /// <summary>
    /// Calls the Physics update function of the respective state and it's sub states.
    /// </summary>
    public void UpdatePhysicsStates()
    {
        UpdatePhysics();
        CurrentSubState?.UpdatePhysicsStates();
    }
    /// <summary>
    /// Calls the Exit function of the respective state and it's sub states.
    /// </summary>
    public void ExitStates()
    {
        CurrentSubState?.ExitStates();
        ExitState();
    }

    /// <summary>
    /// Set the current active substate of the respective state.
    /// </summary>
    /// <param name="newSubState">The current active sub-state</param>
    public void SetSubState(BaseHierarchicalState<S> newSubState)
    {
        CurrentSubState = newSubState;
        newSubState?.SetSuperState(this);
    }
    /// <summary>
    /// Sets the super-state of the respective state.
    /// </summary>
    /// <param name="newSuperState">The super state state of the respective state</param>
    public void SetSuperState(BaseHierarchicalState<S> newSuperState)
    {
        CurrentSuperState = newSuperState;
    }
}
