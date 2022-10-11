using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStates
{
    public UnitSelectedState SelectedState { get; private set; }
    public UnitIdleState IdleState { get; private set; }
    public UnitMoveState MoveState { get; private set; }
    public UnitAttackState AttackState { get; private set; }

    public UnitStates(UnitController unitController, UnitStateController stateController)
    {
        SelectedState = new UnitSelectedState(unitController, stateController, UnitState.State.Selected);
        IdleState = new UnitIdleState(unitController, stateController, UnitState.State.Idle);
        MoveState = new UnitMoveState(unitController, stateController, UnitState.State.Move);
        AttackState = new UnitAttackState(unitController, stateController, UnitState.State.Attack);
    }
}
