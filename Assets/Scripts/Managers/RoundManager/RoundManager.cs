using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class RoundManager : MonoBehaviour
{
    // TODO: stages and phases -> 2.2, 2.3, 3.0 ...
    [SerializeField] private int _roundCount;
    [SerializeField] private RoundState.State _currentState;

    public RoundStateController StateController { get; private set; }
    public RoundStates RoundStates { get; private set; }
    public RoundState.State CurrentState { get { return _currentState; } set { _currentState = value; } }

    public int Round => _roundCount;

    public void IncreaseRoundCount()
    {
        _roundCount += 1;
    }

    private void Awake()
    {
        StateController = new();

        RoundStates = new(this, StateController);
    }

    private void Start()
    {
        RegisterEvents();
        
        StateController.Start(RoundStates.BuyingState);
    }

    private void Update()
    {
        StateController.CurrentState.LogicalUpdates();
    }

    private void FixedUpdate()
    {
        StateController.CurrentState.PhysicalUpdates();
    }

    private void LateUpdate()
    {
        StateController.CurrentState.AnimationUpdates();
    }
}
