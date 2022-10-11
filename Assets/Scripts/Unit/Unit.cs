using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    None,
    Ally,
    Enemy,
}

public enum AttackType
{
    Melee,
    Range,
}

public class Unit : UnitController
{
    private Dictionary<string, Attribute> _attributes = new(); // TODO: find better way of adding the attributes

    [Header("Stats")]
    [SerializeField] protected string _name;
    [SerializeField] protected Attribute _movementSpeed;
    [SerializeField] protected Attribute _attackDamage;
    [SerializeField] protected Attribute _attackSpeed;
    [SerializeField] protected Attribute _attackRange;
    [SerializeField] protected AttackType _attackType;
    [SerializeField] protected Attribute _health;
    [SerializeField] protected Attribute _mana;
    [SerializeField] protected UnitType _type;

    public string Name { get { return _name; } set { _name = value; } }
    public float MovementSpeed { get { return _movementSpeed.Current; } }
    public float AttackDamage { get { return _attackDamage.Current; } }
    public float AttackSpeed { get { return _attackSpeed.Current; } }
    public float AttackRange { get { return _attackRange.Current; } }
    public AttackType AttackType { get { return _attackType; } }
    public float HP { get { return _health.Current; } set { _health.Current = value; } }
    public float Mana { get { return _mana.Current; } }
    public UnitType Type { get { return _type; } set { _type = value; } }

    protected override void Awake()
    {
        base.Awake();

        AddAllAttributes();
        InitializeAttributes();
    }

    protected override void Start()
    {
        base.Start();
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

    private void AddAllAttributes()
    {
        _attributes.Add(nameof(_movementSpeed), _movementSpeed);
        _attributes.Add(nameof(_attackDamage), _attackDamage);
        _attributes.Add(nameof(_attackRange), _attackRange);
        _attributes.Add(nameof(_attackSpeed), _attackSpeed);
        _attributes.Add(nameof(_health), _health);
        _attributes.Add(nameof(_mana), _mana);
    }

    private void InitializeAttributes()
    {
        foreach (var attribute in _attributes)
        {
            if (attribute.Value.Initialize() == false)
            {
                Debug.LogWarning("You have not set value for: " + attribute.Key);
            }
        }
    }

    public void RoundResetAttributes()
    {
        foreach (var attribute in _attributes)
        {
            attribute.Value.RoundReset();
        }
    }

    public bool CanBeSpawnedOnBench() => MapManager.GetNextAvailableTileOnBench() != null;
}
