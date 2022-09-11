using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    private Unit thisUnit { get { return GetComponent<Unit>(); } }

    [SerializeField] private UnitState.State _currentState;
    private Tile _occupiedTile;

    public UnitStateController StateController { get; private set; }
    public UnitStates UnitStates { get; private set; }

    public UnitState.State CurrentState { get { return _currentState; } set { _currentState = value; } }
    public Tile OccupiedTile => _occupiedTile;
    public bool IsOnBench => OccupiedTile.IsBenchTile;

    protected virtual void Awake()
    {
        // initializing the StateController
        StateController = new();
        // initializing all the unit states  
        UnitStates = new(this, StateController);
    }

    protected virtual void Start()
    {
        // starting the StateController
        StateController.Start(UnitStates.IdleState);
    }

    protected virtual void Update()
    {
        StateController.CurrentState.LogicalUpdates();
    }

    protected virtual void FixedUpdate()
    {
        StateController.CurrentState.PhysicalUpdates();
    }

    protected virtual void LateUpdate()
    {
        StateController.CurrentState.AnimationUpdates();
    }

    public void InstantiateUnit()
    {
        // Debug.Log("InstantiateUnit: " + this);
        Instantiate(this.gameObject);
    }

    public void SpawnUnit()
    {
        // Debug.Log("SpawnUnit: " + this);
        PlaceUnit(GameManager.Singleton.MapManager.GetNextAvailableTileOnBench());

        GameManager.Singleton.EventManager.GameEvents.AllyUnitSpawned.Invoke(thisUnit);
    }

    public void SelectUnit()
    {
        // Debug.Log("SelectUnit: " + this);

        this._occupiedTile = null;

        StateController.ChangeState(UnitStates.SelectedState);

        GameManager.Singleton.EventManager.GameEvents.AllyUnitSelected.Invoke(thisUnit);
    }

    public void PlaceUnit(Tile tile)
    {
        // Debug.Log("PlaceUnit: " + this);

        this.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, -1);

        this._occupiedTile = tile;

        StateController.ChangeState(UnitStates.IdleState);

        GameManager.Singleton.EventManager.GameEvents.AllyUnitPlaced.Invoke(thisUnit, tile);
    }

    public void DragUnit(float selectedOffset)
    {
        var pos = GameManager.GetMouseWorldPosition();
        this.gameObject.transform.position = new Vector3(pos.x + selectedOffset, pos.y + selectedOffset, gameObject.transform.position.z);
    }
}
