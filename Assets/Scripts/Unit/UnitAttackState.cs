using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttackState : UnitState
{
    public UnitAttackState(UnitController unitController, UnitStateController stateController, State state) : base(unitController, stateController, state)
    {
    }

    public override void Enter()
    {
        base.Enter();

        UnitController.timeForNextAttack = startTime + (1 / UnitController.thisUnit.AttackSpeed);
        Debug.Log(UnitController.timeForNextAttack);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdates()
    {
        base.LogicalUpdates();

        // Debug.Log(UnitController.timeForNextAttack);
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
        

        if (Time.time >= UnitController.timeForNextAttack && !UnitController.Target.unit.isDead)
        {
            UnitController.AttackTarget();
            UnitController.timeForNextAttack = Time.time + (1 / UnitController.thisUnit.AttackSpeed);
        }
    }

    public override void AnimationUpdates()
    {
        base.AnimationUpdates();
    }
}
