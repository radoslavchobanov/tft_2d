using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitState
{
    protected UnitController thisUnit;
    protected UnitStateController StateController;

    protected float startTime;

    public enum State
    {
        Selected,
        Idle,
        Move,
        Attack,
    }
    public State _state { get; private set; }

    public UnitState(UnitController unitController, UnitStateController stateController, State state)
    {
        this.thisUnit = unitController;
        this.StateController = stateController;
        this._state = state;
    }

    public virtual void Enter()
    {
        // Debug.Log(UnitController.gameObject + " Enters " + _state);

        thisUnit.CurrentState = _state;

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
