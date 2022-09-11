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
    [SerializeField] protected UnitType _type;

    public string Name { get { return _name; } set { _name = value; } }
    public float MovementSpeed { get { return _movementSpeed; } set { _movementSpeed = value; } }
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
