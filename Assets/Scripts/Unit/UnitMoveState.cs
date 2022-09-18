using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMoveState : UnitState
{
    public UnitMoveState(UnitController unitController, UnitStateController stateController, State state) : base(unitController, stateController, state)
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
        
        UnitController.DetectNearestEnemy();

        if (UnitController.Target.GetUnit() != null && UnitController.Target.GetDistance() <= UnitController.thisUnit.AttackRange)
            UnitController.StateController.ChangeState(UnitController.UnitStates.AttackState);
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();

        if (UnitController.Target.GetUnit() == null)
            UnitController.MoveForward(UnitController.forwardDirection);
        else
            UnitController.MoveTowardsTarget();
    }

    public override void AnimationUpdates()
    {
        base.AnimationUpdates();
    }
}
