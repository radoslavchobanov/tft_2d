using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameController : MonoBehaviour
{
    [SerializeField] private GameState.State _currentState;
    
    public GameStateController StateController { get; private set; }
    public GameStates GameStates { get; private set; }
    
    public GameState.State CurrentState { get { return _currentState; } set { _currentState = value; } }

    private void Awake() 
    {
        StateController = new();

        GameStates = new(this, StateController);

        RegisterEvents();
    }

    private void Start()
    {
        StateController.Start(GameStates.PlayState);
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
