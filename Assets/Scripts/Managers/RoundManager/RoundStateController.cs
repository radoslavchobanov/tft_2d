using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStateController
{
    public RoundState CurrentState { get; private set; }

    public void Start(RoundState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(RoundState newState)
    {
        if (CurrentState == newState)
            return;

        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
