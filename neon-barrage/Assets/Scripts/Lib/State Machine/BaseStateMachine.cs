using UnityEngine;

public abstract class BaseStateMachine : MonoBehaviour
{
    public StateFactory StateFactory { get; protected set; }

    public IState CurrentState { get; set; }



    protected virtual void Awake()
    {
        InitializeStates();
    }

    /// <summary>
    /// Initialize the states of the state machine here.
    /// </summary>
    public abstract void InitializeStates();
}
