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

        thisUnit.PathFindingController.Start();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdates()
    {
        base.LogicalUpdates();
        
        thisUnit.DetectNearestEnemy();

        if (thisUnit.Target.GetUnit() != null && 
            thisUnit.Target.GetDistance() <= thisUnit.thisUnit.AttackRange && 
            thisUnit.PathFindingController.HasArrived == true)
        {
            thisUnit.OccupiedTile.IsBusy = false;
            thisUnit.StateController.ChangeState(thisUnit.UnitStates.AttackState);
        }
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();

        if (thisUnit.Target.GetUnit() == null)
            thisUnit.MoveForward();
        else
            thisUnit.MoveTowardsTarget();
    }

    public override void AnimationUpdates()
    {
        base.AnimationUpdates();
    }
}
