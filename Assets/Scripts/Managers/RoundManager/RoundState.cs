using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundState
{
    protected RoundManager RoundManager;
    protected RoundStateController StateController;

    protected float startTime;

    public enum State
    {
        Buying,
        Fighting,
    }
    public State _state { get; private set; }

    public RoundState(RoundManager roundManager, RoundStateController stateController, State state)
    {
        this.RoundManager = roundManager;
        this.StateController = stateController;
        this._state = state;
    }

    public virtual void Enter()
    {
        // Debug.Log(UnitController.gameObject + " Enters " + _state);

        RoundManager.CurrentState = _state;

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
