using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents
{
    public UnityEvent<Unit> AllyUnitClicked = new();
    public UnityEvent<Unit> AllyUnitSelected = new();
    public UnityEvent<Unit, Tile> AllyUnitPlaced = new();
    public UnityEvent<Unit> AllyUnitBought = new();
    public UnityEvent<Unit> AllyUnitInstantiated = new();
    public UnityEvent<Unit> AllyUnitSpawned = new();
    public UnityEvent<Unit> AllyUnitDied = new();

    public UnityEvent<GameObject> AllyTileClicked = new();


    public UnityEvent StoreRefreshed = new();
    public UnityEvent XPBought = new();


    public UnityEvent BuyRoundStart = new();
    public UnityEvent FightRoundStart = new();
}
