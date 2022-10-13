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

        UnitController.PathFindingController.Enable();
    }

    public override void Exit()
    {
        base.Exit();

        UnitController.PathFindingController.Disable();
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
            UnitController.MoveForward();
        else
            UnitController.MoveTowardsTarget();
    }

    public override void AnimationUpdates()
    {
        base.AnimationUpdates();
    }
}
