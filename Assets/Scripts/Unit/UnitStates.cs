using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStates
{
    public UnitIdleState IdleState { get; private set; }
    public UnitSelectedState SelectedState { get; private set; }

    public UnitStates(UnitController unitController, UnitStateController stateController)
    {
        IdleState = new UnitIdleState(unitController, stateController, UnitState.State.Idle);
        SelectedState = new UnitSelectedState(unitController, stateController, UnitState.State.Selected);
    }
}
