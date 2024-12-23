using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public PlayerState CurrentState { get; private set; }

    public void Update()
    {
        CurrentState?.UpdateLogic();
    }

    public void FixedUpdate()
    {
        CurrentState?.PhysicsLogic();
    }

    public void Initialize(PlayerState defaultState)
    {
        CurrentState = defaultState;
        CurrentState.Enter();
    }

    public void ChangeState(PlayerState newState, StateParameters? parameters = null)
    {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState?.Enter(parameters);
    }
}
