using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedState : UnitState
{
    private const float SELECTED_OFFSET = 1;

    public UnitSelectedState(UnitController unitController, UnitStateController stateController, State state) : base(unitController, stateController, state)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdates()
    {
        base.LogicalUpdates();
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();

        UnitController.DragUnit(SELECTED_OFFSET);
    }

    public override void AnimationUpdates()
    {
        base.AnimationUpdates();
    }
}
