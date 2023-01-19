using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public partial class UnitManager
{
    public void RegisterEvents()
    {
        EventManager.Instance.Register(EventID.AllyUnitLeftClicked, OnAllyUnitLeftClicked);
        EventManager.Instance.Register(EventID.UnitRightClicked, OnAllyUnitRightClicked);

        EventManager.Instance.Register(EventID.AllyTileClicked, OnAllyTileClicked);
        EventManager.Instance.Register(EventID.AllyUnitBought, OnAllyUnitBought);
        EventManager.Instance.Register(EventID.AllyUnitInstantiated, OnAllyUnitInstantiated);
        EventManager.Instance.Register(EventID.AllyUnitSpawned, OnAllyUnitSpawned);

        EventManager.Instance.Register(EventID.FightRoundStart, OnFightRoundStart);
        EventManager.Instance.Register(EventID.BuyRoundStart, OnBuyRoundStart);
    }

    private void OnAllyUnitLeftClicked(object args)
    {
        Unit clickedUnit = (Unit)args;

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

    private void OnAllyUnitRightClicked(object args)
    {
        Unit clickedUnit = (Unit)args;
        ToggleStatsWindow(clickedUnit);
    }

    private void OnAllyTileClicked(object args)
    {
        GameObject clickedTileObj = (GameObject)args;

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

    private void OnAllyUnitBought(object args)
    {
        Unit boughtUnit = (Unit)args;
        // Debug.Log("OnAllyUnitBought: " + boughtUnit.gameObject);
        InstantiateAllyUnit(boughtUnit);
    }

    private void OnAllyUnitInstantiated(object args)
    {
        Unit instantiatedUnit = (Unit)args;
        // Debug.Log("OnAllyUnitInstantiated: " + instantiatedUnit.gameObject);
        SpawnAllyUnit(instantiatedUnit);
    }

    private void OnAllyUnitSpawned(object args)
    {
        Unit spawnedUnit = (Unit)args;
        // Debug.Log("OnAllyUnitSpawned: " + spawnedUnit.gameObject);

        // TODO: check if there is other 2 same units ... and combine them for lvl 2 unit
    }

    private void OnFightRoundStart(object args)
    {
        // store start positions of all the units on the battleground
        foreach (var unit in AllyUnitsOnBattleground)
        {
            AllyUnitsStartPositions.Add(unit, unit.OccupiedTile);
        }
    }

    private void OnBuyRoundStart(object args)
    {
        // place all units on the battleground on the starting positions
        foreach (var unit in AllyUnitsStartPositions.Keys)
        {
            RoundResetUnit(unit);
        }

        AllyUnitsStartPositions.Clear();
    }
}
