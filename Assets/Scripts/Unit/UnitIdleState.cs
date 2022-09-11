using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitIdleState : UnitState
{
    public UnitIdleState(UnitController unitController, UnitStateController stateController, State state) : base(unitController, stateController, state)
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
    }
    
    public override void AnimationUpdates()
    {
        base.AnimationUpdates();
    }
}
