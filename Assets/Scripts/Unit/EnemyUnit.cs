using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit
{
    Tile startTile;

    protected override void Awake()
    {
        base.Awake();

        Type = UnitType.Enemy;

        GameManager.Singleton.UnitManager.EnemyUnits.Add(thisUnit);

        GameManager.Singleton.EventManager.GameEvents.BuyRoundStart.AddListener(OnBuyRoundStart);
    }

    protected override void Start()
    {
        base.Start();

        startTile = GameManager.Singleton.MapManager.GetTile(5, 7);
        PlaceUnit(startTile);
    }

    private void OnBuyRoundStart()
    {
        RoundResetUnit();
        PlaceUnit(startTile);
    }
}
