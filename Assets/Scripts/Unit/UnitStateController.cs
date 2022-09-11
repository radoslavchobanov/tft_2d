using System;

public class UnitStateController
{
    public UnitState CurrentState { get; private set; }

    public void Start(UnitState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(UnitState newState)
    {
        if (CurrentState == newState)
            return;

        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
