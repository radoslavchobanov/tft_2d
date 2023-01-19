using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundBuyingState : RoundState
{
    public RoundBuyingState(RoundManager roundManager, RoundStateController stateController, State state) : base(roundManager, stateController, state)
    {
    }

    public override void Enter()
    {
        base.Enter();

        EventManager.Instance.Invoke(EventID.BuyRoundStart);
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
