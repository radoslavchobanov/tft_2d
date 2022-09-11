using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFightingState : GameState
{
    public GameFightingState(GameController gameController, GameStateController stateController, State state) : base(gameController, stateController, state)
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
