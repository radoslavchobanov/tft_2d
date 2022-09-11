using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UnitManager : MonoBehaviour
{
    private GameEvents GameEvents => GameManager.Singleton.EventManager.GameEvents;

    private (bool, Unit) _allyUnitSelected = (false, null);

    public List<Unit> Units = new(); // All units
    public List<Unit> AllyUnits = new(); // All Ally units
    public List<Unit> AllyUnitsOnBench = new(); // All Ally units on the bench
    public List<Unit> AllyUnitsOnBattleground = new(); // All Ally units on the battleground

    public List<Unit> EnemyUnits = new(); // All Enemy units

    public bool IsAllyUnitSelected => _allyUnitSelected.Item1;
    public Unit SelectedUnit => _allyUnitSelected.Item2;

    private void Awake()
    {
    }

    private void Start()
    {
        RegisterEvents();
    }

    private void Update()
    {
    }

    private void AddUnitToBenchList(Unit unit) => AllyUnitsOnBench.Add(unit);
    private void RemoveUnitFromBenchList(Unit unit) => AllyUnitsOnBench.Remove(unit);
    private void AddUnitToBattlegroundList(Unit unit) => AllyUnitsOnBattleground.Add(unit);
    private void RemoveUnitFromBattlegroundList(Unit unit) => AllyUnitsOnBattleground.Remove(unit);

    private void SelectAllyUnit(Unit unit)
    {
        if (unit.IsOnBench == true)
            RemoveUnitFromBenchList(unit);
        else RemoveUnitFromBattlegroundList(unit);

        _allyUnitSelected.Item1 = true;
        _allyUnitSelected.Item2 = unit;

        unit.SelectUnit();
    }

    private void PlaceAllyUnit(Unit unit, Tile tile)
    {
        if (tile.IsBenchTile == true)
            AddUnitToBenchList(unit);
        else AddUnitToBattlegroundList(unit);
        
        _allyUnitSelected.Item1 = false;
        _allyUnitSelected.Item2 = null;

        unit.PlaceUnit(tile);
    }

    private void InstantiateAllyUnit(Unit unit)
    {
        Units.Add(unit);
        AllyUnits.Add(unit);

        unit.InstantiateUnit();
    }

    private void SpawnAllyUnit(Unit unit)
    {
        AllyUnitsOnBench.Add(unit);

        unit.SpawnUnit();
    }
}