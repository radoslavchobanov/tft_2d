using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameEvents
{
    public UnityEvent<Unit> AllyUnitClicked = new();
    public UnityEvent<Unit> AllyUnitSelected = new();
    public UnityEvent<Unit, Tile> AllyUnitPlaced = new();
    public UnityEvent<Unit> AllyUnitBought = new();
    public UnityEvent<Unit> AllyUnitInstantiated = new();
    public UnityEvent<Unit> AllyUnitSpawned = new();

    public UnityEvent<GameObject> AllyTileClicked = new();


    public UnityEvent StoreRefreshed = new();
}
