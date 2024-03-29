#define USING_PATHFINDING

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class UnitController : MonoBehaviour
{
    [Header("Object Components")]
    public Slider HpBar;
    public UnitStatsPanelController UnitStatsPanelController;
    public PathFindingController PathFindingController;
    [Header("Controller")]
    [SerializeField] private UnitState.State _currentState;
    [SerializeField] private Target _target;
    [SerializeField] private Tile _occupiedTile;

    public UnitState.State CurrentState { get { return _currentState; } set { _currentState = value; } }
    public Target Target { get { return _target; } set { _target = value; } }
    public Tile OccupiedTile => _occupiedTile;

    public UnitStateController StateController { get; private set; }
    public UnitStates UnitStates { get; private set; }

    [HideInInspector] public Vector3 forwardDirection = new Vector3(0, 1, 0);
    [HideInInspector] public float timeForNextAttack = 0f;
    [HideInInspector] public bool isDead => thisUnit.HP <= 0;
    [HideInInspector] public bool IsOnBench => OccupiedTile.IsBenchTile;

    public Unit thisUnit { get { return GetComponent<Unit>(); } }

    protected virtual void Awake()
    {
        InitializeController();
    }

    protected virtual void Start()
    {
        RegisterEvents();
        RoundResetUnit();
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

    private void InitializeController()
    {
        Target = new();
        // initializing the StateController
        StateController = new();
        // initializing all the unit states  
        UnitStates = new(this, StateController);
    }

    public void DetectNearestEnemy()
    {
        var enemies = thisUnit.Type == UnitType.Enemy ? GameManager.Instance.UnitManager.AllyUnits : GameManager.Instance.UnitManager.EnemyUnits;

        float shortestDistance = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            // Debug.Log(GameManager.GetDistanceBetweenObjects(thisUnit.gameObject, enemy.gameObject));
            var distanceToObject = GameManager.GetDistanceBetweenObjects(thisUnit.gameObject, enemy.gameObject);

            if (distanceToObject <= Target.DetectionRange && distanceToObject <= shortestDistance && enemy.IsOnBench == false)
            {
                shortestDistance = distanceToObject;
                var direction = (enemy.gameObject.transform.position - this.gameObject.transform.position).normalized;
                Target = new Target(enemy, distanceToObject, direction);
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
        PlaceUnit(MapManager.GetNextAvailableTileOnBench());

        EventManager.Instance.Invoke(EventID.AllyUnitSpawned, thisUnit);
    }

    public void SelectUnit()
    {
        // Debug.Log("SelectUnit: " + this);

        this._occupiedTile = null;

        StateController.ChangeState(UnitStates.SelectedState);

        EventManager.Instance.Invoke(EventID.AllyUnitSelected, thisUnit);
    }

    public void PlaceUnit(Tile tile)
    {
        // Debug.Log("PlaceUnit: " + this);

        this.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, -1);

        this._occupiedTile = tile;

        StateController.ChangeState(UnitStates.IdleState);

        EventManager.Instance.Invoke(EventID.AllyUnitPlaced, (object)(thisUnit, tile));
    }

    public void DragUnit(float selectedOffset)
    {
        var pos = GameManager.GetMouseWorldPosition();
        this.gameObject.transform.position = new Vector3(pos.x + selectedOffset, pos.y + selectedOffset, gameObject.transform.position.z);
    }

    public void MoveTowardsDirection(Vector2 dir)
    {
        var direction = new Vector3(dir.x, dir.y, 0);
        // transform.up = direction;
        this.gameObject.transform.position += direction.normalized * (thisUnit.MovementSpeed / 10) * Time.deltaTime;
    }

    public void MoveForward()
    {
        MoveTowardsDirection(forwardDirection);
    }

    public void MoveTowardsTarget()
    {
#if !USING_PATHFINDING
        MoveTowardsDirection(Target.GetDirection());
#else
        PathFindingController.Updates();
#endif
    }

    public void MoveToTile(Tile tile)
    {
        if (Vector2.Distance(this.transform.position, tile.transform.position) <= 0.1f)
        {
            this.gameObject.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, transform.position.z);
            _occupiedTile = tile;
        }
        else
        {
            MoveTowardsDirection(tile.transform.position - OccupiedTile.transform.position);
        }
    }

    public void AttackTarget()
    {
        // Coroutine to check if the attack animation is fully done, to deal dmg
        var targetUnit = Target.GetUnit();

        targetUnit.TakeDamage(thisUnit.AttackDamage);
        if (targetUnit.HP <= 0)
        {
            Debug.Log(targetUnit.Name + " is killed by " + thisUnit.Name);
            targetUnit.Die();
        }
    }

    public void TakeDamage(float damage)
    {
        // Debug.Log("TakeDamage: " + this.name);

        thisUnit.HP -= damage;

        HpBar.value -= damage;
    }

    public void Die()
    {
        // Debug.Log("Die: " + this.name);

        MapManager.SendToGraveyard(thisUnit);

        thisUnit.gameObject.SetActive(false);
    }

    public void RoundResetUnit()
    {
        gameObject.SetActive(true);
        Target.Remove();
        thisUnit.RoundResetAttributes();

        HpBar.maxValue = thisUnit.HP;
        HpBar.value = HpBar.maxValue;
    }
}