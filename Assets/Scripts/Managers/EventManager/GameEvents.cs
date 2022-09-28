using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents
{
    // Unit events
    public UnityEvent<Unit> UnitRightClicked = new();

    // Ally unit events
    public UnityEvent<Unit> AllyUnitLeftClicked = new();
    public UnityEvent<Unit> AllyUnitSelected = new();
    public UnityEvent<Unit, Tile> AllyUnitPlaced = new();
    public UnityEvent<Unit> AllyUnitBought = new();
    public UnityEvent<Unit> AllyUnitInstantiated = new();
    public UnityEvent<Unit> AllyUnitSpawned = new();
    public UnityEvent<GameObject> AllyTileClicked = new();

    // Store events
    public UnityEvent StoreRefreshed = new();
    public UnityEvent XPBought = new();

    // Round events
    public UnityEvent BuyRoundStart = new();
    public UnityEvent FightRoundStart = new();
}
