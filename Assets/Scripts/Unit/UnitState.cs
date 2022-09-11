using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitState
{
    protected UnitController UnitController;
    protected UnitStateController StateController;

    protected float startTime;

    public enum State
    {
        Idle,
        Move,
        Selected,
    }
    public State _state { get; private set; }

    public UnitState(UnitController unitController, UnitStateController stateController, State state)
    {
        this.UnitController = unitController;
        this.StateController = stateController;
        this._state = state;
    }

    public virtual void Enter()
    {
        // Debug.Log(UnitController.gameObject + " Enters " + _state);

        UnitController.CurrentState = _state;

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
