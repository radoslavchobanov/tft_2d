using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UnitController : MonoBehaviour
{
    public Unit thisUnit { get { return GetComponent<Unit>(); } }

    
    [Header("Controller")]
    [SerializeField] private UnitState.State _currentState;
    [SerializeField] private Target _target;
    private Tile _occupiedTile;

    public UnitStateController StateController { get; private set; }
    public UnitStates UnitStates { get; private set; }

    public UnitState.State CurrentState { get { return _currentState; } set { _currentState = value; } }
    public Target Target => _target;
    public Tile OccupiedTile => _occupiedTile;
    public bool IsOnBench => OccupiedTile.IsBenchTile;

    public Vector3 forwardDirection = new Vector3(0, 1, 0);
    public float timeForNextAttack = 0f;
    public bool isDead => thisUnit.HP <= 0;

    protected virtual void Awake()
    {
        // initializing the StateController
        StateController = new();
        // initializing all the unit states  
        UnitStates = new(this, StateController);

        RegisterEvents();

        // Find better way of adding units to lists !!!
        if (thisUnit.Type == UnitType.Enemy)
        {
            GameManager.Singleton.UnitManager.EnemyUnits.Add(thisUnit);
        }
        else
        {
            GameManager.Singleton.UnitManager.AllyUnits.Add(thisUnit);
        }
    }

    protected virtual void Start()
    {
        // starting the StateController
        StateController.Start(UnitStates.IdleState);
    }

    protected virtual void Update()
    {
        DetectNearestEnemy();

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

    private void DetectNearestEnemy()
    {
        var enemies = thisUnit.Type == UnitType.Enemy ? GameManager.Singleton.UnitManager.AllyUnits : GameManager.Singleton.UnitManager.EnemyUnits;

        foreach (var enemy in enemies)
        {
            // Debug.Log(GameManager.GetDistanceBetweenObjects(this.gameObject, enemy.gameObject));
            var distanceToObject = GameManager.GetDistanceBetweenObjects(this.gameObject, enemy.gameObject);
            if (distanceToObject <= Target.DetectionRange)
            {
                _target.unit = enemy;
                _target._distance = distanceToObject;
                _target._direction = (enemy.gameObject.transform.position - this.gameObject.transform.position).normalized;
            }
        }
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

    public void MoveTowardsDirection(Vector2 dir)
    {
        var direction = new Vector3(dir.x, dir.y, 0);
        transform.up = direction;
        this.gameObject.transform.position += direction.normalized * thisUnit.MovementSpeed * Time.deltaTime;
    }

    public void MoveForward(Vector2 forwardDirection)
    {
        MoveTowardsDirection(forwardDirection);
    }

    public void MoveTowardsTarget()
    {
        MoveTowardsDirection(Target._direction);
    }

    public void AttackTarget()
    {
        Debug.Log("AttackTarget");
        
        Target.unit.TakeDamage(thisUnit.AttackDamage);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("TakeDamage: " + this.name);

        thisUnit.HP -= damage;
    }
}