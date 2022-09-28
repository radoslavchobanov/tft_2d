using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UnitManager
{
    public void RegisterEvents()
    {
        GameEvents.AllyUnitLeftClicked.AddListener(OnAllyUnitLeftClicked);
        GameEvents.UnitRightClicked.AddListener(OnAllyUnitRightClicked);

        GameEvents.AllyTileClicked.AddListener(OnAllyTileClicked);
        GameEvents.AllyUnitBought.AddListener(OnAllyUnitBought);
        GameEvents.AllyUnitInstantiated.AddListener(OnAllyUnitInstantiated);
        GameEvents.AllyUnitSpawned.AddListener(OnAllyUnitSpawned);

        GameEvents.FightRoundStart.AddListener(OnFightRoundStart);
        GameEvents.BuyRoundStart.AddListener(OnBuyRoundStart);
    }

    private void OnAllyUnitLeftClicked(Unit clickedUnit)
    {
        if (IsAllyUnitSelected == false)
        {
            SelectAllyUnit(clickedUnit);
        }
        else if (IsAllyUnitSelected == true && SelectedUnit != clickedUnit)
        {
            var clickedUnitTile = clickedUnit.OccupiedTile;

            PlaceAllyUnit(SelectedUnit, clickedUnitTile);
            SelectAllyUnit(clickedUnit);
        }
    }

    private void OnAllyUnitRightClicked(Unit clickedUnit)
    {
        ToggleStatsWindow(clickedUnit);
    }

    private void OnAllyTileClicked(GameObject clickedTileObj)
    {
        Tile clickedTile = null;
        clickedTileObj.TryGetComponent<Tile>(out clickedTile);
        if (clickedTile == null)
        {
            Debug.Log($"UnitManager: {clickedTileObj.name} is not a Tile !");
            return;
        }

        var objectOnTile = clickedTile.GetObjectOnTile();
        Unit unitOnTile = null;
        objectOnTile?.TryGetComponent<Unit>(out unitOnTile);

        if (IsAllyUnitSelected == false && unitOnTile != null)
        {
            SelectAllyUnit(unitOnTile);
        }
        else if (IsAllyUnitSelected == true)
        {
            if (unitOnTile == null)
            {
                PlaceAllyUnit(SelectedUnit, clickedTile);
            }
            else
            {
                PlaceAllyUnit(SelectedUnit, clickedTile);
                SelectAllyUnit(unitOnTile);
            }
        }
    }

    private void OnAllyUnitBought(Unit boughtUnit)
    {
        // Debug.Log("OnAllyUnitBought: " + boughtUnit.gameObject);
        InstantiateAllyUnit(boughtUnit);
    }

    private void OnAllyUnitInstantiated(Unit instantiatedUnit)
    {
        // Debug.Log("OnAllyUnitInstantiated: " + instantiatedUnit.gameObject);
        SpawnAllyUnit(instantiatedUnit);
    }

    private void OnAllyUnitSpawned(Unit spawnedUnit)
    {
        // Debug.Log("OnAllyUnitSpawned: " + spawnedUnit.gameObject);

        // TODO: check if there is other 2 same units ... and combine them for lvl 2 unit
    }

    private void OnFightRoundStart()
    {
        foreach (var unit in AllyUnitsOnBattleground)
        {
            AllyUnitsStartPositions.Add(unit, unit.OccupiedTile);
        }
    }

    private void OnBuyRoundStart()
    {
        foreach (var unit in AllyUnitsStartPositions.Keys)
        {
            RoundResetUnit(unit);
        }

        AllyUnitsStartPositions.Clear();
    }
}
