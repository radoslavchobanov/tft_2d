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

        thisUnit.timeForNextAttack = startTime + (1 / thisUnit.thisUnit.AttackSpeed);
        // Debug.Log(UnitController.timeForNextAttack);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdates()
    {
        base.LogicalUpdates();

        if (thisUnit.Target.GetUnit().isDead == true)
        {
            thisUnit.Target.Remove();
            StateController.ChangeState(thisUnit.UnitStates.MoveState);
        }
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
        
        if (Time.time >= thisUnit.timeForNextAttack && !thisUnit.Target.GetUnit().isDead)
        {
            thisUnit.AttackTarget();
            thisUnit.timeForNextAttack = Time.time + (1 / thisUnit.thisUnit.AttackSpeed);
        }
    }

    public override void AnimationUpdates()
    {
        base.AnimationUpdates();
    }
}
