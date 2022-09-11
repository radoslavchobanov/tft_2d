using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    protected GameController GameController;
    protected GameStateController StateController;

    protected float startTime;

    public enum State
    {
        Play,
        Pause,

        Buying,
        Fighting,
    }
    public State _state { get; private set; }

    public GameState(GameController gameController, GameStateController stateController, State state)
    {
        this.GameController = gameController;
        this.StateController = stateController;
        this._state = state;
    }

    public virtual void Enter()
    {
        // Debug.Log(UnitController.gameObject + " Enters " + _state);

        GameController.CurrentState = _state;

        startTime = Time.time;
    }

    public virtual void LogicalUpdates()
    {
        // Debug.Log(UnitController.gameObject + " is " + _state);
    }

    public virtual void PhysicalUpdates()
    {
    }

    public virtual void AnimationUpdates()
    {
    }

    public virtual void Exit()
    {
        // Debug.Log(UnitController.gameObject + " Exits " + _state);
    }
}
