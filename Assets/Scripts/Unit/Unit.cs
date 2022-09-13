using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    None,
    Ally,
    Enemy,
}

public class Unit : UnitController
{
    [SerializeField] protected string _name;
    [SerializeField] protected float _movementSpeed;
    [SerializeField] protected float _attackDamage;
    [SerializeField] protected float _attackSpeed;
    [SerializeField] protected float _attackRange;
    [SerializeField] protected float _health;
    [SerializeField] protected float _mana;
    [SerializeField] protected UnitType _type;

    public string Name { get { return _name; } set { _name = value; } }
    public float MovementSpeed { get { return _movementSpeed; } set { _movementSpeed = value; } }
    public float AttackDamage { get { return _attackDamage; } set { _attackDamage = value; } }
    public float AttackSpeed { get { return _attackSpeed; } set { _attackSpeed = value; } }
    public float AttackRange { get { return _attackRange; } set { _attackRange = value; } }
    public float HP { get { return _health; } set { _health = value; } }
    public float Mana { get { return _mana; } set { _mana = value; } }
    public UnitType Type { get { return _type; } set { _type = value; } }

    protected override void Awake()
    {
        base.Awake();
        InitializeUnitStats();
    }

    protected override void Start()
    {
        base.Start();

        // this runs as soon as this Unit is Instantiated
        GameManager.Singleton.EventManager.GameEvents.AllyUnitInstantiated.Invoke(this);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
    }

    protected virtual void InitializeUnitStats()
    {
    }

    public bool CanBeSpawnedOnBench() => GameManager.Singleton.MapManager.GetNextAvailableTileOnBench() != null;
}
